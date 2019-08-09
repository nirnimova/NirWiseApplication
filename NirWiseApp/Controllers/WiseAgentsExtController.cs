using NirWiseApp.data;
using NirWiseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace NirWiseApp.Controllers
{
    public class WiseAgentsExtController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResult SearchWiseAgents(Agent agent)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.SearchWiseAgents(agent).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }
    }
}
