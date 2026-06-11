using System.ComponentModel.DataAnnotations;

namespace LeetTracker.DTOs;

public record class CreateAttemptDto(
    [Required] int ProblemId,
    [Required] DateOnly Date,
    [Required] float TimeTaken,
    string? Notes,
    [Required] bool Successful

);
