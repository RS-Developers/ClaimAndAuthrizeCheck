using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Linq;
using System.Security.Claims;

namespace TeamTreeHouses.Models
{
    public class User : IPrincipal
    {
        /*** Private Part ***/
        private string _lUserName = string.Empty;
        private string _lPassword = string.Empty;

        private void CreateIdentity()
        {
            this.Identity = new GenericIdentity(string.Format("{0}_{1}", this.UserName, this.Password), this.GetType().FullName);
            (this.Identity as GenericIdentity).AddClaim(new Claim("Id", this.Id.ToString()));
        }

        /*** Public Part ***/
        [Required]
        [StringLength(50)]
        public string UserName
        {
            get { return _lUserName; }
            set
            {
                _lUserName = value;
                CreateIdentity();
            }
        }
        [Required]
        [StringLength(50)]
        public string Password
        {
            get { return _lPassword; }
            set
            {
                _lPassword = value;
                CreateIdentity();
            }
        }
        public Nullable<bool> IsDeleted { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Permission> AdditionalPermission { get; set; }
        //
        [NotMapped]
        public IIdentity Identity
        {
            get;
            private set;
        }

        public User()
        {
            this.Roles = new HashSet<Role>();
            this.AdditionalPermission = new HashSet<Permission>();
        }

        public bool IsInRole(string role)
        {
            var lResult = this.Roles.Any(lRole => lRole.Permissions.Any(permission => permission.Title == role));
            if (!lResult)
                return this.AdditionalPermission.Any(permission => permission.Title == role);
            return lResult;
        }
    }
}