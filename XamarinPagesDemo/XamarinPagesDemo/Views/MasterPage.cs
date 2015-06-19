using System;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class MasterPage: TabbedPage
	{
		public MasterPage ()
		{
			this.Children.Add (new ToDoHomePage () { Title = "Load Todo Items", Icon = "csharp.png" });
			this.Children.Add (new TodoAddItem () { Title = "Add Todo Item",Icon = "xaml.png" });
		}
	}
}

