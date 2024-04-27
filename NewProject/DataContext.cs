﻿using Microsoft.EntityFrameworkCore;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    public DbSet<User> User { get; set; } = default!;
    public DbSet<Product> Product { get; set; } = default!;
    public DbSet<ProductInfo> ProductInfo { get; set; } = default!;


}
