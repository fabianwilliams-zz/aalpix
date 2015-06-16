using System;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class MasterPage: TabbedPage
	{
		public MasterPage ()
		{
			this.Children.Add (new CSharpPage () { Title = "C-Sharp Page", Icon = "csharp.png" });
			this.Children.Add (new XAMLPage () { Title = "XAML Page",Icon = "xaml.png" });
		}
	}
}

