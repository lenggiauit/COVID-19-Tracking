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

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = roleId,
                    RoleName = "Administrator",
                    RoleColor = "#F0680A",
                    IsPublish = true,
                    IsActive = true
                }
            );

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


            modelBuilder.Entity<Permission>().HasData(
               new Permission
               {
                   Id = permissionId,
                   PermissionName = "Administrator",
                   PermissionCode = "Administrator",
                   PermissionGroup = "Admin",
                   IsActive = true
               }

            );

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

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userId,
                    FirebaseUid = "S6hmQ2zmhQd3kKw5hguYKkmg0Wz1",
                    UserName = "Admin",
                    FirstName = "Giàu",
                    LastName = "Lê Ngọc",
                    Images = "https://scontent.fsgn4-1.fna.fbcdn.net/v/t31.0-8/17359301_1831231470465460_8548873343809066948_o.jpg?_nc_cat=100&_nc_ohc=MAJ76r4otogAX-OrKNB&_nc_ht=scontent.fsgn4-1.fna&oh=2ea8ae99b0a71fc53ea891bcc54c0f2b&oe=5EFE5A69",
                    Password = "password1",
                    RoleID = roleId,
                    UserEmail = "lenggiauit@gmail.com",
                    UserPhone = "+84 909458492",
                    Address = "So 2, Duong N4, Phuong Son Ky, Tan Phu, Ho Chi Minh",
                    Note = "Account admin",
                    IsBanned = false,
                    IsActive = true
                }
            );

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId);
                entity.Property(e => e.SettingName);
                entity.Property(e => e.SettingValue);
                entity.Property(e => e.SettingValidation);
                entity.Property(e => e.SettingHintText);
                entity.Property(e => e.CreatedBy);
                entity.Property(e => e.UpdateDate);
                entity.Property(e => e.CreatedDate);
                entity.Property(e => e.UpdateBy);
            });

            modelBuilder.Entity<UserSetting>().HasData(
             new UserSetting
             {
                 Id = Guid.NewGuid(),
                 UserId = userId,
                 SettingName = "Setting 1",
                 SettingValue = "Setting 1",
                 SettingValidation = "",
                 SettingHintText = "PE00000000000",
             });


 


        }
    }
}
