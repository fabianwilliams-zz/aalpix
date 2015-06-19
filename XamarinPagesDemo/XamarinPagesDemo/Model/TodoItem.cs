using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;

namespace XamarinPagesDemo
{
	public class TodoItem
	{
		public string Id { get; set; }
		public string Text { get; set; }
		public bool Complete { get; set; }
	}
}

