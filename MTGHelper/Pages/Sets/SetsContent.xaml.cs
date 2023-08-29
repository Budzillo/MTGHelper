namespace MTGHelper.Views;

public partial class SetsContent : ContentView
{
	public SetsContent()
	{
		InitializeComponent();
	}

    private void SearchBar_Unfocused(object sender, FocusEventArgs e)
    {
		if(sender is SearchBar search) search.Unfocus();	
    }
}