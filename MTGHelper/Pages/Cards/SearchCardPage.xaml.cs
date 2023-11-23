namespace MTGHelper.Pages;

public partial class SearchCardPage : ContentPage
{
	public SearchCardPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        entryCardName.IsEnabled = false; 
        entryCardName.IsEnabled = true; 
    }
}