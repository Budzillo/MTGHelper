using MTGHelper.ViewModels;

namespace MTGHelper.Views;

public partial class VerticalCommanderDamageContent : ContentView
{
	public VerticalCommanderDamageContent()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid && this.BindingContext is CommanderDamageContentViewModel viewModel)
        {
            viewModel.GridTappedVertical(grid, e);
        }
    }
}