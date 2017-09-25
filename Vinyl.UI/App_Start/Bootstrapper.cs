using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Vinyl.UI.App_Start
{
    public class Bootstrapper
    {
		public static void Run()
		{
			//Configure AutoFac  
			AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
		}
	}
}
