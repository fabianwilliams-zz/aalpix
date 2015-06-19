using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinPagesDemo
{
	public class TodoAddItem : ContentPage
	{
		private TodoService tdService;
		public List<TodoItem> Items { get; private set; }

		public TodoAddItem ()
		{
			tdService = new TodoService ();

			var todoTextLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Text = "Enter your ToDo Item",
				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};

			var todoTextEntry = new Entry ();

			var buttonSave = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				Text = "Save Item"
			};

			buttonSave.Clicked += async (sender, e) => {
				if (string.IsNullOrWhiteSpace (todoTextEntry.Text))
					return;
				
				var newItem = new TodoItem {
					Id = Guid.NewGuid().ToString(),
					Text = todoTextEntry.Text,
					Complete = false
				};

				await tdService.InsertTodoItemAsync(newItem);

			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (20),
				Children = {
					todoTextLabel,todoTextEntry,buttonSave
				}
			};


		}
	}
}

