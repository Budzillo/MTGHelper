namespace MTGHelper.Views;

public partial class FlipCoinContent : ContentView
{
	public FlipCoinContent()
	{
		InitializeComponent();
	}
	public async Task FlipCoin()
	{
		int rotationFrom = this.gridCoin.RotationY == 0 ? 0 : 360;
		int rotationTo = rotationFrom == 0 ? 360 : 0;	
        await MainThread.InvokeOnMainThreadAsync(() => {
           var animation = new Animation(v => gridCoin.RotationY = v, rotationFrom, rotationTo);
           animation.Commit((IAnimatable)gridCoin, "RotateCoinAnimation", 16, 500, Easing.Linear);
       });      
    }
}