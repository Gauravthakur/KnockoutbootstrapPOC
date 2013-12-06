using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace KnockoutBootStrap.Core.Util
{
    public static class Common
    {
        public static string ConnString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["BackboneConnectionString"].ConnectionString;
            }
        }
    }
}