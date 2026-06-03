using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace LeetTracker.DTOs;

public record class CreateProblemDto(
    [Required][StringLength(100)] string Title,
    [Required] string Difficulty,
    [Required] string Category,
    bool Status
);
