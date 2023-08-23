using MTGHelper.ViewModels;

namespace MTGHelper.Views;

public partial class HorizontalReversePlayerLifeContent : ContentView
{
	public HorizontalReversePlayerLifeContent()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (this.BindingContext is PlayerLifeTotalViewModel viewModel)
        {
            if (sender is Grid grid)
            {
                viewModel.GridTappedHorizontal(grid, e);
            }
        }
    }
}