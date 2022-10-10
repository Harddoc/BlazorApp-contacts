using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Category
    {

        public int? Id { get; set; }

        public string Cat { get; set; }
        public int? SubCatId { get; set; }
    }
}
