namespace LeetTracker.DTOs;

public record class AttemptResponse(
    int Id,
    int ProblemId,
    string ProblemTitle,
    DateOnly Date,
    float TimeTaken,
    string? Notes,
    bool Successful
);
