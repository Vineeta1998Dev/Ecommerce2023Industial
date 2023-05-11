using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewEcommerc.Models
{
    public class MainPageData
    {
        ECOMMERCEEntities db = new ECOMMERCEEntities();
        public List<Mstr_categories> GetAllTypes()
        {
            List<Mstr_categories> lstCat = new List<Mstr_categories>();
            lstCat = db.Mstr_categories.Where(x => x.Pid == 0).ToList();
            return lstCat;
        }
        public List<Mstr_categories> GetAllCategoriesByPId(int id)
        {
            List<Mstr_categories> lstCat = new List<Mstr_categories>();
            lstCat = db.Mstr_categories.Where(x => x.Pid == id).ToList();
            return lstCat;
        }
    }
}