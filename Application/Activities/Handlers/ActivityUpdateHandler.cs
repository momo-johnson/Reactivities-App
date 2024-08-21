using System;
using Application.Activities.Commands;
using AutoMapper;
using Infrastructure.AppDbContext;
using MediatR;

namespace Application.Activities.Handlers
{
    public class ActivityUpdateHandler : IRequestHandler<UpdateActivityCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActivityUpdateHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _dbContext.Activities.FirstOrDefault(activity => activity.ID == request.ActivityUpdateRequest.ID);
            if( activity != null)
            {
                _mapper.Map(request.ActivityUpdateRequest, activity);
                await _dbContext.SaveChangesAsync();
            }
            

        }
    }
}

