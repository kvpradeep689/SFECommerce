using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace SalesFusionECommerce
{
    public class item
    {
        [Key]
        public string id { get; set; }
        public string item_name { get; set; }
        public string description { get; set; }
        public string brand_id { get; set; }
        public string master_fit_family_id { get; set; }
        public string subcategory_id { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string on_sale { get; set; }
        public string is_live { get; set; }
        public string item_price { get; set; }
        public string item_original_price { get; set; }

        public override string ToString()
        {
            return string.Format("Name: '{0}', Description: '{1}'", item_name, description);
        }
    }
}
