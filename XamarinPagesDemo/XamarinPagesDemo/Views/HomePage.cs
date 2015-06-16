using System;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	// Adding a Content Page that as of now will just be called from the Shared Code (XamarinPagesDemo.cs) aka app.cs
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			//Adding Padding so that on iPhone it will not potentially bleed into the top icons
			Padding = new Thickness (0, Device.OnPlatform (20,0,0), 0, 0);
			Title = "Learn Mobile w/ Fabian";
			//Adding Views(Controls) on the page to make it pretty we will do an image, labels and a button
			var splashImage = new Image {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Source = "http://www.fabiangwilliams.com/wp-content/uploads/2015/06/LearnXamarinWFabian.png"
			};
			var splashMessage = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Text = "Learn about Xamarin from @FabianWilliams",
				FontSize = 17,
			};
			var buttonGetMasterPage = new Button {
				Text = "Master Page",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BorderWidth = 1,
				BorderColor = Color.White,
				BackgroundColor = Color.Black
			};
			//set an Event Reciever that will Push the Page to a Master Page
			buttonGetMasterPage.Clicked += (sender, e) => {
				Navigation.PushAsync(new MasterPage());
			};
			Content = new StackLayout {
				Spacing = 10,
				Children = {splashImage, splashMessage, buttonGetMasterPage}
			};

		}
	}
}

