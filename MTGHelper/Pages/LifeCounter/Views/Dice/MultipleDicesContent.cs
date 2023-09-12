using MTGHelper.Views;

namespace MTGHelper.Pages.LifeCounter.Views.Dice;

public class MultipleDicesContent : ContentView
{
	List<ContentView> contentViews;
	public MultipleDicesContent(List<ContentView> contents)
	{
		this.Margin = 10;
		this.VerticalOptions = LayoutOptions.Center;
		this.contentViews = contents;
        FlexLayout flexLayout = new FlexLayout();
        flexLayout.Direction = Microsoft.Maui.Layouts.FlexDirection.Row;
		flexLayout.AlignItems = Microsoft.Maui.Layouts.FlexAlignItems.Center;
		flexLayout.JustifyContent = Microsoft.Maui.Layouts.FlexJustify.SpaceEvenly;
		flexLayout.VerticalOptions = LayoutOptions.Fill;
		flexLayout.HorizontalOptions = LayoutOptions.Fill;
		flexLayout.Wrap = Microsoft.Maui.Layouts.FlexWrap.Wrap;

        foreach (ContentView content in contents)
		{
            flexLayout.Children.Add(content);
		}
		Content = new ScrollView
		{
			FlowDirection = FlowDirection.LeftToRight,
			HorizontalOptions = LayoutOptions.Fill,
			Content = flexLayout
        };
        this.Loaded += MultipleDicesContent_Loaded;
	}

    private void MultipleDicesContent_Loaded(object sender, EventArgs e)
    {
        foreach(ContentView content in contentViews) 
		{
			if (content is FlipCoinContent flipCoinContent)
				flipCoinContent.FlipCoin();

        }
    }
}