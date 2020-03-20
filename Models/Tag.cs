using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public String TagName { get; set; }

        

       // [ForeignKey("ItemId")]
       // public int ItemId { get; set; }
        //public Tag ItemName { get; set; }


      //  public virtual IList<Item> Items { get; set; }
    }
}
