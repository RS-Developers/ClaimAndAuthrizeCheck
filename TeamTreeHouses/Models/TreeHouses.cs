using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamTreeHouses.Interfaces;

namespace TeamTreeHouses.Models
{
    public class TreeHouses : DbContext, IPermissionManager
    {
        /*** Public Part ***/
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ComicBook> ComicBooks { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public TreeHouses()
            : this("DefaultConnection")
        {
        }

        public TreeHouses(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TreeHouses, Migrations.Configuration>());
        }

        public bool HaveAccessToPermission(int userId, int permissionId)
        {
            return this.Users
                .Any(user =>
                    user.Id == userId &&
                    (user.AdditionalPermission.Any(permission => permission.Id == permissionId) ||
                     user.Roles.Any(role => role.Permissions.Any(permission => permission.Id == permissionId)))
                );
        }

        public bool HaveAccessToPermission(int userId, string permissionTitle)
        {
            return this.Users
                .Any(user =>
                    user.Id == userId &&
                    (user.AdditionalPermission.Any(permission => permission.Title == permissionTitle) ||
                     user.Roles.Any(role => role.Permissions.Any(permission => permission.Title == permissionTitle)))
                );
        }
    }
}