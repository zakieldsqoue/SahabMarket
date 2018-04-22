using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Model;
namespace BL.BLClass
{
   public class CategoriesBL
    {
        Categories CategoriesDl = new Categories();
        public List<object> FindAll()
        {
            return CategoriesDl.FindAll();
        }



    }
}
