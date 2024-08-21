using Domain.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Activities.Queries
{
    public class GetActivityListQuery : IRequest<List<ActivityResponse>>{}
}

