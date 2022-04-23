using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Abstract
{
    public interface IActivityService
    {
        int AddActivity(Activity activity);
        int UpdateActivity(Activity activity);
        int DeleteActivity(int activityId);
        Task<List<Activity>>  GetCompletedActivities();
        Task<List<Activity>>  GetPendingActivities();
        
    }
}
