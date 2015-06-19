using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#if __IOS__
using UIKit;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;


namespace XamarinPagesDemo
{
	public class TodoService
	{
		private MobileServiceClient MobileService = new MobileServiceClient(
			"https://pcdserver.azure-mobile.net/",
			"OLJpreavvHyJUHafYxKmRvafIhjqvY37"
		);

		public List<TodoItem> Items { get; private set;}

		private IMobileServiceSyncTable<TodoItem> todoTable;

		public async Task InitializeAsync()
		{
			var store = new MobileServiceSQLiteStore("localdata.db");
			store.DefineTable<TodoItem> ();
			await this.MobileService.SyncContext.InitializeAsync(store);

			todoTable = this.MobileService.GetSyncTable<TodoItem>();
		}

		public async Task SyncAsync()
		{
			// Comment this back in if you want auth
			//if (!await IsAuthenticated())
			//    return;
			await InitializeAsync();
			await this.MobileService.SyncContext.PushAsync();

			var query = todoTable.CreateQuery()
				.Where(td => td.Complete == false)
				;
			await todoTable.PullAsync("TodoItems", query);
		}

		public async Task<List<TodoItem>> GetAllTodoItems()
		{
			try {
				// update the local store
				// all operations on todoTable use the local database, call SyncAsync to send changes
				await SyncAsync(); 							
				// This code refreshes the entries in the list view by querying the local TodoItems table.
				// The query excludes completed TodoItems -- not anymore
				Items = await todoTable
					.Where (ga => ga.Complete == false).ToListAsync ();
			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
				return null;
			}
			return Items;
		}

		public async Task InsertTodoItemAsync (TodoItem todoItem)
		{
			try {                
				await SyncAsync();
				await todoTable.InsertAsync (todoItem); // Insert a new TodoItem into the local database. 
				await SyncAsync(); // send changes to the mobile service

			} catch (MobileServiceInvalidOperationException e) {
				Console.Error.WriteLine (@"ERROR {0}", e.Message);
			}
		}

	}
}

