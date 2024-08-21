using System;
using Application.Activities.Commands;
using Infrastructure.AppDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities.Handlers
{
    public class ActivityDeleteHandler : IRequestHandler<ActivityDeleteRequest>

    {
        private readonly ApplicationDbContext _dbContext;

        public ActivityDeleteHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Handle(ActivityDeleteRequest request, CancellationToken cancellationToken)
        {
            var activity = await _dbContext.Activities.FirstOrDefaultAsync(activity => activity.ID == request.ID);
            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

