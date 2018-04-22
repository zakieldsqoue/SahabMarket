using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Model;
namespace BL.BLClass
{
    public class UsersBL
    {
        public string GetEmailByName(string Name) {
            return new AspNetUsers().GetEmailByName(Name);
        }
    }
}
