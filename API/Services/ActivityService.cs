using API.Data;
using API.Entities;
using API.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class ActivityService : IActivityService
    {
        private DataBaseContext _dbContext;
        public ActivityService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddActivity(Activity activity)
        {
             _dbContext.Activities.Add(activity);
            return _dbContext.SaveChanges();
            
        }
        public int DeleteActivity(int activityId)
        {
            Activity deleteActivity = _dbContext.Activities.AsNoTracking().Where(a => a.Id == activityId).FirstOrDefault();
            _dbContext.Entry(deleteActivity).State = EntityState.Deleted;
            return _dbContext.SaveChanges();
        }

        public async Task<List<Activity>> GetCompletedActivities()
        {
            return await  _dbContext.Activities.AsNoTracking().Where(a => a.Status == "Completed").ToListAsync();
      
        }
        public async Task<List<Activity>> GetPendingActivities()
        {
            return await _dbContext.Activities.AsNoTracking().Where(a => a.Status == "Pending").ToListAsync();

        }     
        public int UpdateActivity(Activity activity)
        {
            _dbContext.Entry(activity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }
    }
}
