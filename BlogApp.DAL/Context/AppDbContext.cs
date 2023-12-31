﻿using BlogApp.Core.Entities;
using BlogApp.Core.Entities.Account;
using BlogApp.DAL.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //    modelBuilder.ApplyConfiguration(new StudentConfiguration());
        //    modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        //    modelBuilder.ApplyConfiguration(new CourseConfiguration());
        //    modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        //}

        // Global Models in App
        public DbSet<Category> Categories { get; set; }

        // Base Models in App
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        
    }
}
