using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System.Threading.Tasks;

namespace CRM_Core_3.Controllers
{
    public class ProjectTaskController(ServiceClient service) : Controller
    {
        private readonly ServiceClient _service = service;
        [HttpPost]
        public ActionResult Associate(string[] selectedTasks, string project_id)
        {
            try
            {
                Entity project = new("new_project")
                {
                    Id = new Guid(project_id)
                };

                List<EntityReference> erSelectedTasks = [];

                foreach (string taskId in selectedTasks)
                {
                    EntityReference entityRef = new("cr267_projecttask", new Guid(taskId));
                    erSelectedTasks.Add(entityRef);
                }

                AssociateRequest associateRequest = new()
                {
                    Target = new EntityReference("new_project", new Guid(project_id)),
                    RelatedEntities = new EntityReferenceCollection(erSelectedTasks),
                    Relationship = new Relationship("cr267_projecttask_ProjectV2_new_project")
                };

                _service.Execute(associateRequest);

                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public IActionResult Disassociate(string task_id, string project_id)
        {
            try
            {
                DisassociateRequest disassociateRequest = new()
                {
                    Target = new EntityReference("new_project", new Guid(project_id)),
                    RelatedEntities =
                    [
                        new EntityReference("cr267_projecttask", new Guid(task_id))
                    ],
                    Relationship = new Relationship("cr267_projecttask_ProjectV2_new_project")
                };

                _service.Execute(disassociateRequest);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
