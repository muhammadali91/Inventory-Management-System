using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class ItemBranch
    {
        [Key]
        [Column(Order =1)]
        public int ItemId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BranchId { get; set; }

        //public virtual Branch Branches { get; set; }

       //public virtual Item Items { get; set; }

        [ForeignKey("ItemId")]
        public Item items { get; set; }
        [ForeignKey("BranchId")]
        public Branch branches { get; set; }

    }
}
