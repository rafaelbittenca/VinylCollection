using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vinyl.UI.Models;

namespace Vinyl.UI.Extension
{
	public abstract class MessageControllerBase : Controller
	{
		public MessageControllerBase()
		{
			Toastr = new Toastr();
		}
		public Toastr Toastr { get; set; }

		public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
		{
			return Toastr.AddToastMessage(title, message, toastType);
		}
	}
}
