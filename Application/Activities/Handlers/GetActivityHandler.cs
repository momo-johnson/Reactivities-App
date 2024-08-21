using System;
using Application.Activities.Queries;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.AppDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Handlers
{
    public class GetActivityHandler : IRequestHandler<GetActivityQuery, ActivityResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActivityHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ActivityResponse> Handle(GetActivityQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ActivityResponse>(await _dbContext.Activities.FirstOrDefaultAsync(activity => activity.ID == request.ID));
        }
    }
}

