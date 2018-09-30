using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamTreeHouses.Models
{
    public class Permission
    {
        /*** Public Part ***/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        //
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> AdditionalUsers { get; set; }
    }
}