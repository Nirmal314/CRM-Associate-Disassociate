using ExampleProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CRM_Core_3.Controllers
{
    public class TaskController(ServiceClient service) : Controller
    {
        private readonly ServiceClient _service = service;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTask(string project_id)
        {
            var query = new QueryExpression("cr267_projecttask")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
            };

            query.Criteria.AddCondition("cr267_projectv2", ConditionOperator.Equal, project_id);

            EntityCollection result = _service.RetrieveMultiple(query);

            List<cr267_Projecttask> tasks = [];
            cr267_Projecttask _task = new();

            foreach (var project in result.Entities)
            {
                _task = new()
                {
                    cr267_Description = ((cr267_Projecttask)project).cr267_Description,
                    cr267_Duedate = ((cr267_Projecttask)project).cr267_Duedate,
                    cr267_Taskname = ((cr267_Projecttask)project).cr267_Taskname,
                    cr267_Probabilityofwin = ((cr267_Projecttask)project).cr267_Probabilityofwin,
                    cr267_Isemailsent = ((cr267_Projecttask)project).cr267_Isemailsent,
                    cr267_ProjecttaskId = ((cr267_Projecttask)project).cr267_ProjecttaskId,
                    cr267_ProjectV2 = ((cr267_Projecttask)project).cr267_ProjectV2,
                    cr267_projecttask_ProjectV2_new_project = ((cr267_Projecttask)project).cr267_projecttask_ProjectV2_new_project

                };
                tasks.Add(_task);
            }

            return PartialView("_ProjectTasks", tasks);
        }

        public ActionResult GetAllTasks()
        {
            QueryExpression query = new("cr267_projecttask")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
            };

            //query.Criteria.AddCondition("cr267_projectv2", ConditionOperator.Equal, new Guid(project_id));

            EntityCollection tasks = _service.RetrieveMultiple(query);
            return Json(new { tasks, success = true });
        }
    }
}
