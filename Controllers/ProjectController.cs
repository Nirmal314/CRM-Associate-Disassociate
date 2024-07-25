using ExampleProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Diagnostics;
using Microsoft.PowerPlatform.Dataverse.Client;
using System.Collections.Generic;

namespace CRM_Core_3.Controllers
{
    public class ProjectController(ServiceClient service) : Controller
    {
        private readonly ServiceClient _service = service;

        public ActionResult Index()
        {
            var query = new QueryExpression("new_project")
            {
                ColumnSet = new ColumnSet(true),
                //LinkEntities = {
                //    new LinkEntity()
                //    {
                //        LinkFromEntityName = "new_project",
                //        LinkToEntityName = "cr267_projecttask",
                //        LinkFromAttributeName = "new_projectid",
                //        LinkToAttributeName = "cr267_projectv2",
                //        JoinOperator = JoinOperator.LeftOuter,
                //        Columns = new ColumnSet(true)
                //    }
                //}
            };

            EntityCollection result = _service.RetrieveMultiple(query);

            List<new_Project> projects = [];
            new_Project _project = new();

            foreach (var project in result.Entities)
            {
                _project = new()
                {
                    new_Description = ((new_Project)project).new_Description,
                    new_Projectname = ((new_Project)project).new_Projectname,
                    new_priority = ((new_Project)project).new_priority,
                    new_FYID = ((new_Project)project).new_FYID,
                    new_PINcode = ((new_Project)project).new_PINcode,
                    new_ProjectId = ((new_Project)project).new_ProjectId,
                };
                projects.Add(_project);
            }

            return View(projects);
        }
    }
}
