using MtgApiManager.Lib.Model;
using MTGHelper.Helpers;
using Scryfall.API.Models;
using System.Collections.ObjectModel;

namespace MTGHelper.Controls;

public partial class LegalityControl : ContentView
{
    public Legality Legality
    {
        get => (Legality)GetValue(LegalityProperty);
        set => SetValue(LegalityProperty, value);
    }

    public static readonly BindableProperty LegalityProperty = BindableProperty.Create(nameof(Legality), typeof(Legality), typeof(Legality), new Legality(), BindingMode.TwoWay, propertyChanged: LegalityChanged);


    public LegalityControl()
	{
		InitializeComponent();
	}
    private static void LegalityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LegalityControl legalityControl && newValue is Legality legality)
        {

            legalityControl.gridLayoutRoot.Children.Clear();
            legalityControl.gridLayoutRoot.ColumnDefinitions.Clear();
            legalityControl.gridLayoutRoot.RowDefinitions.Clear();

            LegalStatusToColorConverter legalStatusToColorConverter = new LegalStatusToColorConverter();

            legalityControl.gridLayoutRoot.AddColumnDefinition(new ColumnDefinition());
            legalityControl.gridLayoutRoot.AddColumnDefinition(new ColumnDefinition());
            legalityControl.gridLayoutRoot.AddColumnDefinition(new ColumnDefinition());

            legalityControl.gridLayoutRoot.AddRowDefinition(new RowDefinition());
            legalityControl.gridLayoutRoot.AddRowDefinition(new RowDefinition());
            legalityControl.gridLayoutRoot.AddRowDefinition(new RowDefinition());
            legalityControl.gridLayoutRoot.AddRowDefinition(new RowDefinition());
            AddLabel("Standard", legalStatusToColorConverter.ConvertWithoutParameters(legality.Standard), legalityControl.gridLayoutRoot, 0, 0);
            AddLabel("Future", legalStatusToColorConverter.ConvertWithoutParameters(legality.Future), legalityControl.gridLayoutRoot, 1, 0);
            AddLabel("Frontier", legalStatusToColorConverter.ConvertWithoutParameters(legality.Frontier), legalityControl.gridLayoutRoot, 2, 0);
            AddLabel("Modern", legalStatusToColorConverter.ConvertWithoutParameters(legality.Modern), legalityControl.gridLayoutRoot, 0, 1);
            AddLabel("Legacy", legalStatusToColorConverter.ConvertWithoutParameters(legality.Legacy), legalityControl.gridLayoutRoot, 1, 1);
            AddLabel("Pauper", legalStatusToColorConverter.ConvertWithoutParameters(legality.Pauper), legalityControl.gridLayoutRoot, 2, 1);
            AddLabel("Vintage", legalStatusToColorConverter.ConvertWithoutParameters(legality.Vintage), legalityControl.gridLayoutRoot, 0, 2);
            AddLabel("Penny", legalStatusToColorConverter.ConvertWithoutParameters(legality.Penny), legalityControl.gridLayoutRoot, 1, 2);
            AddLabel("Commander", legalStatusToColorConverter.ConvertWithoutParameters(legality.Commander), legalityControl.gridLayoutRoot, 2, 2);
            AddLabel("OnevOne", legalStatusToColorConverter.ConvertWithoutParameters(legality.OnevOne), legalityControl.gridLayoutRoot, 0, 3);
            AddLabel("Duel", legalStatusToColorConverter.ConvertWithoutParameters(legality.Duel), legalityControl.gridLayoutRoot, 1, 3);
            AddLabel("Brawl", legalStatusToColorConverter.ConvertWithoutParameters(legality.Brawl), legalityControl.gridLayoutRoot, 2, 3);

        }
    }
    private static void AddLabel(string text,Color color, Grid grid,int column,int row)
    {
        Label label = new Label() { Text = text, TextColor = color };
        grid.Children.Add(label);
        Grid.SetRow(label, row);
        Grid.SetColumn(label, column);
    }
}