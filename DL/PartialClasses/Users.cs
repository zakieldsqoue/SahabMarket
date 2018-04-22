using DL.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Model
{
  public  partial class AspNetUsers
    {
        public string GetEmailByName(string Name)
        {
            return (from a in Global.Context.AspNetUsers where a.UserName == Name select a.Email).First();
        }
    }
}
