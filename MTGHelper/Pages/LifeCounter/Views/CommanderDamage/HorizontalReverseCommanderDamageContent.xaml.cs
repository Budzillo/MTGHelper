using MTGHelper.ViewModels;

namespace MTGHelper.Views;

public partial class HorizontalReverseCommanderDamageContent : ContentView
{
	public HorizontalReverseCommanderDamageContent()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Grid grid && this.BindingContext is CommanderDamageContentViewModel viewModel)
        {
            viewModel.GridTappedHorizontalReverse(grid, e);
        }
    }
}