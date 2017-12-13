using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Vinyl.Libraries.Tools;
using Vinyl.UI.ViewModels;

namespace Vinyl.UI.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.GoogleMapApiKey = WebConfigurationManager.AppSettings["GoogleMapKey"];
			return View();
		}


		public ActionResult Test()
		{
			return View("Test");
		}

		public ActionResult AboutMe()
		{
			return View("AboutMe");
		}

		[HttpPost]
		public ActionResult Index(EmailContact obj)
		{
			try
			{
				var email = new Email();
				var msgBody = string.Format("<p>Hi {0},</p><p>This is a copy for your message.</p><p>Message:</p><p>{1}</p>", obj.ToName, obj.EMailBody);
				if (email.SendEmail(obj.ToEmail, obj.EmailBCC, obj.EmailCC, obj.ToName, obj.EmailSubject, msgBody))
				{
					ViewBag.Status = "Email Sent Successfully.";
					ModelState.Clear();
				}
			}
			catch (Exception ex)
			{
				ViewBag.Status = string.Format("Problem while sending email, Please check details. ({0})", ex.Message);
			}
			return View();
		}
	}
}