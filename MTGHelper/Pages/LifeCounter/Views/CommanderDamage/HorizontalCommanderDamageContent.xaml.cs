using MTGHelper.ViewModels;

namespace MTGHelper.Views;

public partial class HorizontalCommanderDamageContent : ContentView
{
	public HorizontalCommanderDamageContent()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		if(sender is Grid grid && this.BindingContext is CommanderDamageContentViewModel viewModel)
		{
			viewModel.GridTappedHorizontal(grid,e);
		}
    }
}