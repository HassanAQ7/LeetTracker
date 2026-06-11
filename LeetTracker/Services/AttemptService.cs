using System;
using LeetTracker.Data;
using LeetTracker.DTOs;
using LeetTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace LeetTracker.Services;

public class AttemptService(AppDbContext context)
{

    public async Task<List<AttemptResponse>> GetAllAttempts()
    {
        return await context.Attempts
        .Select(a => new AttemptResponse(
            a.Id,
            a.ProblemId,
            a.AttemptedProblem!.Title,
            a.Date,
            a.TimeTaken,
            a.Notes,
            a.Successful

        )).ToListAsync();
    }

    public async Task<AttemptResponse?> GetAttemptById(int id)
    {
        var result = await context.Attempts
        .Where(a => a.Id == id)
        .Select(a => new AttemptResponse(
            a.Id,
            a.ProblemId,
            a.AttemptedProblem!.Title,
            a.Date,
            a.TimeTaken,
            a.Notes,
            a.Successful
        )).FirstOrDefaultAsync();

        return result;
    }

    public async Task<AttemptResponse> AddAttempt(CreateAttemptDto attempt)
    {
        var newAttempt = new Attempt
        {
            ProblemId = attempt.ProblemId,
            Date = attempt.Date,
            TimeTaken = attempt.TimeTaken,
            Notes = attempt.Notes,
            Successful = attempt.Successful
        };
        context.Attempts.Add(newAttempt);
        await context.SaveChangesAsync();
        return new AttemptResponse(
            newAttempt.Id,
            newAttempt.ProblemId,
            newAttempt.AttemptedProblem!.Title,
            newAttempt.Date,
            newAttempt.TimeTaken,
            newAttempt.Notes,
            newAttempt.Successful
        );
    }

    public async Task<AttemptResponse> UpdateAttemptById(int id, UpdateAttemptDto attempt)
    {
        var attemptToUpdate = await context.Attempts.FindAsync(id);
        if (attemptToUpdate is null)
        {
            return null;
        }
        attemptToUpdate.TimeTaken = attempt.TimeTaken;
        attemptToUpdate.Notes = attempt.Notes;
        attemptToUpdate.Successful = attempt.Successful;
        await context.SaveChangesAsync();
        return new AttemptResponse(
            attemptToUpdate.Id,
            attemptToUpdate.ProblemId,
            attemptToUpdate.AttemptedProblem!.Title,
            attemptToUpdate.Date,
            attemptToUpdate.TimeTaken,
            attemptToUpdate.Notes,
            attemptToUpdate.Successful
        );
    }

    public async Task<bool> DeleteAttempt(int id)
    {
        var attemptToDelete = await context.Attempts.FindAsync(id);
        if (attemptToDelete is null)
        {
            return false;
        }
        context.Attempts.Remove(attemptToDelete);
        await context.SaveChangesAsync();
        return true;
    }
}
