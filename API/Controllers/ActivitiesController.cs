using System.Net;
using Application.Activities.Commands;
using Application.Activities.Handlers;
using Application.Activities.Queries;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.AppDbContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

public class ActivitiesController : BaseApiController

{
    //private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/values
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityResponse>>> Get()
    {
        return Ok( await Mediator.Send(new GetActivityListQuery()));
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityResponse?>> Get(Guid id)
    {
        var activity = await Mediator.Send(new GetActivityQuery { ID = id });
        
       return activity == null ? Problem(title: "Invalid acitivity ID", detail: "The activity id you provided is wrong", statusCode: StatusCodes.Status404NotFound) : Ok(activity);
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(ActivityAddRequest activityAddRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await Mediator.Send(new AddActivityCommand { ActivityRequest = activityAddRequest });

        return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, ActivityUpdateRequest activityUpdateRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);

        }
        activityUpdateRequest.ID = id;
        await Mediator.Send(new UpdateActivityCommand { ActivityUpdateRequest = activityUpdateRequest });

        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Mediator.Send(new ActivityDeleteRequest { ID = id });
        return NoContent();
    }
}

