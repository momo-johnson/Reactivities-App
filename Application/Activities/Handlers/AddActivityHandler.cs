using System;
using Application.Activities.Commands;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AppDbContext;
using MediatR;

namespace Application.Activities.Handlers
{
    public class AddActivityHandler : IRequestHandler<AddActivityCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddActivityHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Handle(AddActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _mapper.Map<Activity>(request.ActivityRequest);
            _dbContext.Activities.Add(activity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

