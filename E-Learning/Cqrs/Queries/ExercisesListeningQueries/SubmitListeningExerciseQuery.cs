using MediatR;
using System;
using System.Collections.Generic;
using E_Learning.Domain.Entities;

namespace E_Learning.Cqrs.Queries.ExercisesListeningQueries
{
    public record UserAnswer(Guid ExerciseListeningId, char SelectedOption);

    public record SubmitListeningExerciseQuery(Guid ExerciseId,Guid UserId,List<UserAnswer> Answers) : IRequest<ExerciseSubmission>;
}
