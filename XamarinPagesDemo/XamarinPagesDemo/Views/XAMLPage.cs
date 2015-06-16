using System;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class XAMLPage : ContentPage
	{
		public XAMLPage ()
		{
			Padding = new Thickness (0, Device.OnPlatform (20,0,0), 0, 0);
			Title = "This is my XAML Page";

			var splashLabel = new Label {
				Text = "Hello, Welcome to the XAML Page",
				FontSize = 15
			};

			Content = new StackLayout {
				Spacing = 10,
				Children = {splashLabel}
			};

		}
	}
}

