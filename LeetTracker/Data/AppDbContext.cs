using System;
using LeetTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace LeetTracker.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Problem> Problems => Set<Problem>();
    public DbSet<Attempt> Attempts => Set<Attempt>();
    
}
