namespace LeetTracker.DTOs;

public record class UpdateAttemptDto(
    float TimeTaken,
    string? Notes,
    bool Successful
);