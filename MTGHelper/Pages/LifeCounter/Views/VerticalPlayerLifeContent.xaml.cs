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
                viewModel.GridTappedVertical(grid, e);
            }
        }
    }
    public async Task FlashRandomFirstPlayer()
    {
        if(this.BindingContext is PlayerLifeTotalViewModel viewModel)
        {
            await viewModel.FlashRandomFirstPlayer(this);
        }
    }
    public async Task ShowFirstPlayer()
    {
        var previousValue = this.labelSelectedValue.Text;
        this.labelSelectedValue.Text = "1St";
        await Task.Delay(3000);
        this.labelSelectedValue.Text = previousValue;
    }
}