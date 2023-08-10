using Microsoft.Maui.Controls;
using MTGHelper.ViewModels;

namespace MTGHelper.Views;

public partial class VerticalPlayerLifeContent : ContentView
{
	public VerticalPlayerLifeContent()
	{
		InitializeComponent();
	}

    private void Grid_Focused(object sender, FocusEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if(this.BindingContext is PlayerLifeTotalViewModel viewModel)
        {
            if(sender is Grid grid)
            {
                viewModel.GridTapped(grid, e);
            }
        }
    }
}