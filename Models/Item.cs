using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string Photo { get; set; }

        public int TestProperty { get; set; }

        //  public IList<ItemBranch> AllBranches { get; set; }

       // public virtual ICollection<Tag> AllTag { get; set; }

        //[ForeignKey("BranchId")]
        //public Branch BranchId { get; set; }
        // public ICollection<ItemBranch> ItemBranch { get; set; }
        [ForeignKey("BranchId")]
      
        public virtual ICollection<ItemBranch> ItemsBranches { get; set; }

        //public virtual IList<Tag> Tags { get; set; }
     //   [ForeignKey("TagId")]
    //    public int TagId { get; set; }
        public String TagName { get; set; }

    }
}
