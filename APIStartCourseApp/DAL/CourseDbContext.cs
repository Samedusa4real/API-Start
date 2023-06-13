﻿using APIStartCourseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace APIStartCourseApp.DAL
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options) { }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
