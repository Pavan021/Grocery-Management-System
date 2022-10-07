using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Models
{
    public class GroceryModel
    {
        [Key]
        public int GroceryId { get; set; }
        [StringLength(30)]
        public string GroceryName { get; set; }
        public string GroceryType { get; set; }
        public int GroceryPrice { get; set; }
        public int GroceryRating { get; set; }

    }
}
