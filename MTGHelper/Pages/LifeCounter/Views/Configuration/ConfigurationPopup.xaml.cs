using CommunityToolkit.Maui.Views;

namespace MTGHelper.Views;

public partial class ConfigurationPoupup : Popup
{
	public ConfigurationPoupup()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }
}