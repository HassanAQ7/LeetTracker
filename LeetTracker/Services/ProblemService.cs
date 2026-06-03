using System;
using LeetTracker.Data;
using LeetTracker.DTOs;
using LeetTracker.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace LeetTracker.Services;

public class ProblemService(AppDbContext context)
{
    public async Task<ProblemResponse> AddProblem(CreateProblemDto problem)
    {
        var newProblem = new Problem
        {
            Title = problem.Title,
            Difficulty = problem.Difficulty,
            Category = problem.Category,
            Status = problem.Status
        };
        context.Problems.Add(newProblem);
        await context.SaveChangesAsync();
        return new ProblemResponse(
            newProblem.Id,
            newProblem.Title,
            newProblem.Difficulty,
            newProblem.Category,
            newProblem.Status
        );

    }

    public async Task<List<ProblemResponse>> GetAllProblems()
    {
        return await context.Problems.Select(p => new ProblemResponse(
            p.Id,
            p.Title,
            p.Difficulty,
            p.Category,
            p.Status
        )).ToListAsync();
    }

    public async Task<ProblemResponse?> GetProblemById(int id)
    {
        var result = await context.Problems
        .Where(p => p.Id == id)
        .Select(p => new ProblemResponse(
            p.Id,
            p.Title,
            p.Difficulty,
            p.Category,
            p.Status

        ))
        .FirstOrDefaultAsync();
        return result;
    }

    public async Task<ProblemResponse?> updateProblemById(int id, UpdateProblemDto problem)
    {
        var problemToUpdate = await context.Problems.FindAsync(id);
        if (problemToUpdate is null)
        {
            return null;
        }
        problemToUpdate.Title = problem.Title;
        problemToUpdate.Difficulty = problem.Difficulty;
        problemToUpdate.Category = problem.Category;
        problemToUpdate.Status = problem.Status;
        await context.SaveChangesAsync();
        return new ProblemResponse(
            id,
            problem.Title,
            problem.Difficulty,
            problem.Category,
            problem.Status
        );

    }

    public async Task<bool> deleteProblem(int id)
    {
        var problemToDelete = await context.Problems.FindAsync(id);
        if (problemToDelete is null)
        {
            return false;
        }
        context.Problems.Remove(problemToDelete);
        await context.SaveChangesAsync();
        return true;
    }


}
