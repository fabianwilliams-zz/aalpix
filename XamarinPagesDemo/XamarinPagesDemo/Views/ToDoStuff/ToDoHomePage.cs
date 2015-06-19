using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class ToDoHomePage : ContentPage
	{
		private ListView listView;
		private TodoService tdService;

		public List<TodoItem> Items { get; private set; }

		public ToDoHomePage ()
		{
			tdService = new TodoService ();

			listView = new ListView {
				HasUnevenRows = true

			};

			var syncButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				Text = "Sync Me"
			};
			syncButton.Clicked += async (object sender, EventArgs e) => {
				try
				{
					syncButton.Text = "Syncing...";
					await tdService.SyncAsync();
					await this.RefreshAsync();
				}
				finally
				{
					syncButton.Text = "Synced";
				}
			};

			this.Title = "All The Crap To Do";
			this.Content = new StackLayout {
				Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0),
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				Children = {
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						Children = {
							syncButton
						}
					},
					listView
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			Items = await tdService.GetAllTodoItems ();
			listView.ItemsSource = Items;

			var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
//			cell.SetBinding(TextCell.TextProperty, "Text"); //the word Text here represents the field in the Database we want returned
//			listView.ItemTemplate = cell;
			//end two lines commentary

			listView.ItemTemplate = new DataTemplate (typeof(TodoItemCell)); //this uses my customized cell to make 2 items in 1 row

		}
	}
}

