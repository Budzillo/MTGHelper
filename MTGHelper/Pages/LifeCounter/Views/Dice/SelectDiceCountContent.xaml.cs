namespace MTGHelper.Pages.LifeCounter.Views.Dice;

public partial class SelectDiceCountContent : ContentView
{
	public SelectDiceCountContent()
	{
		InitializeComponent();
	}
    public SelectDiceCountContent(string diceType)
    {
        InitializeComponent();
        this.selectLabel.Text = $"Select number of {diceType}";
    }
}