using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deml.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }
        public string Author { get; set; }

        [DisplayName("list price")]
        public int ListPrice { get; set; }

        public int Price { get; set; }

        [DisplayName("list price more than 50")]
        public int Price50 { get; set; }

        [DisplayName("list price more than 50")]
        public int Price100 { get; set; }

    }
}
