using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }


        public ICollection<ApplicationUser> AllUsers { get; set; }
        // [ForeignKey("Id")]
        //  public int? Id { get; set; }
        // public IList<ApplicationUser> UsersinBranch { get; set; }
        // public IList<User> Allusers { get; set; }


        // [ForeignKey("ItemId")]
        //public Item ItemId { get; set; }
        // public ICollection<ItemBranch> ItemBranch { get; set; }
        [ForeignKey("ItemId")]
        public Item Items { get; set; }
      
        public virtual ICollection<ItemBranch> ItemsBranches { get; set; }

       // public virtual ICollection<ApplicationUser> ManyUsers { get; set; }
      //  public IList<ItemBranch> AllItems { get; set; }
    }
}
