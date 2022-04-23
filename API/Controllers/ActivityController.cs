using API.Entities;
using API.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ActivityController : Controller
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpPost("AddActivity")]
        public IActionResult AddActivity([FromBody] Activity activity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _activityService.AddActivity(activity);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }             
            }
            return Ok(activity);
        }
        [HttpPut("UpdateActivity")]
        public IActionResult UpdateActivity([FromBody] Activity activity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _activityService.UpdateActivity(activity);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return Ok(activity);
        }
        [HttpDelete("DeleteActivity")]
        public IActionResult DeleteActivity(int activityId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _activityService.DeleteActivity(activityId);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                }
            }
            return Ok();
        }
        //[HttpGet("ListOfCompleted")]
        //public async Task<List<Activity>> GetCompletedActivities()
        //{          
        //        try
        //        {
        //            return await _activityService.GetCompletedActivities();
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("Error", ex.Message);
        //        }
            
        //}
        //[HttpGet("ListOfPending")]
        //public async Task<List<Activity>> GetPendingActivities()
        //{
        //    try
        //    {
        //        await _activityService.GetPendingActivities();
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("Error", ex.Message);
        //    }
            
        //}
    }
}
