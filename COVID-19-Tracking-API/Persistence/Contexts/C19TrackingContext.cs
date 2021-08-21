using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.AspNetCore.Authentication;
using System;
using C19Tracking.API.Domain.Entities;

namespace C19Tracking.API.Persistence.Contexts
{
    public class C19TrackingContext : BaseContext
    { 
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionInRole> PermissionsInRole { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // var global
            Guid roleId = Guid.NewGuid();
            Guid permissionId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            // 
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RoleName);
                entity.Property(e => e.RoleColor);
                entity.Property(e => e.IsPublish);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedBy);
                entity.Property(e => e.UpdateDate);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.UpdateBy);
            });
             
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PermissionName);
                entity.Property(e => e.PermissionCode);
                entity.Property(e => e.PermissionGroup);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedBy);
                entity.Property(e => e.UpdateDate);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.UpdateBy);
            });
             
            modelBuilder.Entity<PermissionInRole>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PermissionId);
                entity.Property(e => e.RoleId);
                entity.Property(e => e.CreatedBy);
                entity.Property(e => e.UpdateDate);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.UpdateBy);
            });
            modelBuilder.Entity<PermissionInRole>().HasData(
              new PermissionInRole
              {
                  Id = Guid.NewGuid(),
                  RoleId = roleId,
                  PermissionId = permissionId,
              }
              );
             
            modelBuilder.Entity<User>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.FirebaseUid);
                 entity.Property(e => e.UserName);
                 entity.Property(e => e.FirstName);
                 entity.Property(e => e.LastName);
                 entity.Property(e => e.Images);
                 entity.Property(e => e.Password);
                 entity.Property(e => e.RoleID);
                 entity.Property(e => e.UserEmail);
                 entity.Property(e => e.UserPhone);
                 entity.Property(e => e.Address);
                 entity.Property(e => e.Note);
                 entity.Property(e => e.IsBanned);
                 entity.Property(e => e.IsActive);
                 entity.Property(e => e.CreatedBy);
                 entity.Property(e => e.UpdateDate);
                 entity.Property(e => e.CreatedDate);
                 entity.Property(e => e.UpdateBy);
             });
             
        }
    }
}
