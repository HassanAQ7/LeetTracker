namespace LeetTracker.DTOs;

public record class ProblemResponse(
    int Id,
    string Title,
    string Difficulty,
    string Category,
    string? Status
);