﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>//将DbContext更改为IdentityDbContext  //将IdentityDbContext更改为IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//使用基类的方法，防止报错
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))//取消AspNetUserRoles表外键级联，更改为不执行（限制操作）
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;//限制
            }
            modelBuilder.Seed();
        }
    }
}
