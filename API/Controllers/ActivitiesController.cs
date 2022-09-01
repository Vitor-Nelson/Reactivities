using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Activities;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        
      

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivity()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] //Activity endpoints activities/id fetch
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }


        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
        }
    }
}