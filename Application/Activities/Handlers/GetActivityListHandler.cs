using Application.Activities.Queries;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.AppDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Handlers
{
    public class GetActivityListHandler : IRequestHandler<GetActivityListQuery, List<ActivityResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActivityListHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ActivityResponse>> Handle(GetActivityListQuery request, CancellationToken cancellationToken)
        {
            var activites = _mapper.Map<List<ActivityResponse>>(await _dbContext.Activities.ToListAsync());
            return activites;
        }
    }
}

