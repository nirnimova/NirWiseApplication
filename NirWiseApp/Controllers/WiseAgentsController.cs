using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using NirWiseApp.Data;

namespace NirWiseApp.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using NirWiseApp.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Agent>("WiseAgents");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class WiseAgentsController : ODataController
    {
        private WiseDBContext db = new WiseDBContext();

        // GET: odata/WiseAgents
        [EnableQuery]
        public IQueryable<Agent> GetWiseAgents()
        {
            return db.Agents;
        }

        // GET: odata/WiseAgents(5)
        [EnableQuery]
        public SingleResult<Agent> GetAgent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Agents.Where(agent => agent.Id == key));
        }

        // PUT: odata/WiseAgents(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Agent> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Agent agent = db.Agents.Find(key);
            if (agent == null)
            {
                return NotFound();
            }

            patch.Put(agent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(agent);
        }

        // POST: odata/WiseAgents
        public IHttpActionResult Post(Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agents.Add(agent);
            db.SaveChanges();

            return Created(agent);
        }

        // PATCH: odata/WiseAgents(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Agent> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Agent agent = db.Agents.Find(key);
            if (agent == null)
            {
                return NotFound();
            }

            patch.Patch(agent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(agent);
        }

        // DELETE: odata/WiseAgents(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Agent agent = db.Agents.Find(key);
            if (agent == null)
            {
                return NotFound();
            }

            db.Agents.Remove(agent);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgentExists(int key)
        {
            return db.Agents.Count(e => e.Id == key) > 0;
        }
    }
}
