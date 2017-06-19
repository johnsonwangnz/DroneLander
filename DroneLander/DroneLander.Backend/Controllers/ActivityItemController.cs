

using DroneLander.Service.DataObjects;
using DroneLander.Service.Models;
using Microsoft.Azure.Mobile.Server;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace DroneLander.Service.Controllers
{
    /**
     * This controller uses the data connection you created in the previous exercise to access an "ActivityItem" table in the database. ActivityItemController derives from TableController, which provides a base implementation for controllers in Azure Mobile Apps and makes it easy to perform create, read, update, and delete (CRUD) operations on data stores connected to those apps.
     * **/
    [Authorize]
    public class ActivityItemController : TableController<ActivityItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            DroneLanderServiceContext context = new DroneLanderServiceContext();
            DomainManager = new EntityDomainManager<ActivityItem>(context, Request);
        }

        // GET tables/ActivityItem
        public IQueryable<ActivityItem> GetAllActivityItems()
        {
            return Query();
        }

        // GET tables/ActivityItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ActivityItem> GetActivityItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ActivityItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ActivityItem> PatchActivityItem(string id, Delta<ActivityItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/ActivityItem
        public async Task<IHttpActionResult> PostActivityItem(ActivityItem item)
        {
            ActivityItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ActivityItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteActivityItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}