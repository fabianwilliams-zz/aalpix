using System;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class CSharpPage : ContentPage
	{
		public CSharpPage ()
		{
			Padding = new Thickness (0, Device.OnPlatform (20,0,0), 0, 0);
			Title = "C-Sharp Page Yalls";

			var splashLabel = new Label {
				Text = "Hello, Welcome to the C# Page",
				FontSize = 15
			};

			Content = new StackLayout {
				Spacing = 10,
				Children = {splashLabel}
			};

		}
	}
}

