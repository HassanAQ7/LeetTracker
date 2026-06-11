using System;

namespace LeetTracker.Models;

public class Attempt
{
    public int Id { get; set; }
    public int ProblemId { get; set; }

    public Problem? AttemptedProblem { get; set; }

    public DateOnly Date { get; set; }

    public float TimeTaken { get; set; }

    public string? Notes { get; set; }

    public bool Successful { get; set; }
}
