using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CodingChallenge.Helper
{
    public class SiteURLHelper
    {
        public static string GetVirtualPath()
        {
            //return HostingEnvironment.ApplicationVirtualPath;// + "/";
            return HostingEnvironment.ApplicationVirtualPath != "/" ? HostingEnvironment.ApplicationVirtualPath + "/" : "/";
        }
    }
}
