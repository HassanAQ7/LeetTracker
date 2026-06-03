using System.ComponentModel.DataAnnotations;

namespace LeetTracker.DTOs;

public record class UpdateProblemDto(
    [StringLength(100)] string Title,
    string Difficulty,
    string Category,
    string Status 
);
