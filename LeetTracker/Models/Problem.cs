using System;

namespace LeetTracker.Models;

public class Problem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Difficulty { get; set; }
    public required string Category { get; set; }

    public string? Status { get; set; }



}
