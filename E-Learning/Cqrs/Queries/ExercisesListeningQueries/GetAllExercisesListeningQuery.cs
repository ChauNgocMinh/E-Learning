using E_Learning.Domain.Entities;
using E_Learning.Models;
using E_Learning.ViewModel;
using MediatR;
using System;

namespace E_Learning.Cqrs.Queries.ExercisesListeningQueries
{
    public record GetAllExercisesListeningQuery(Guid ExerciseId) : IRequest<Exercise>;


}
