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
    builder.EntitySet<Account>("WiseAccounts");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class WiseAccountsController : ODataController
    {
        private WiseDBContext db = new WiseDBContext();

        // GET: odata/WiseAccounts
        [EnableQuery]
        public IQueryable<Account> GetWiseAccounts()
        {
            return db.Accounts;
        }

        // GET: odata/WiseAccounts(5)
        [EnableQuery]
        public SingleResult<Account> GetAccount([FromODataUri] int key)
        {
            return SingleResult.Create(db.Accounts.Where(account => account.Id == key));
        }

        // PUT: odata/WiseAccounts(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Account> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account account = db.Accounts.Find(key);
            if (account == null)
            {
                return NotFound();
            }

            patch.Put(account);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(account);
        }

        // POST: odata/WiseAccounts
        public IHttpActionResult Post(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accounts.Add(account);
            db.SaveChanges();

            return Created(account);
        }

        // PATCH: odata/WiseAccounts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Account> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account account = db.Accounts.Find(key);
            if (account == null)
            {
                return NotFound();
            }

            patch.Patch(account);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(account);
        }

        // DELETE: odata/WiseAccounts(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Account account = db.Accounts.Find(key);
            if (account == null)
            {
                return NotFound();
            }

            db.Accounts.Remove(account);
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

        private bool AccountExists(int key)
        {
            return db.Accounts.Count(e => e.Id == key) > 0;
        }
    }
}
