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
    public class WiseAccountsExtController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResult SearchWiseAccounts(Account account)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.SearchWiseAccounts(account).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult SearchTopWiseAccounts(TopAccount data)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.SearchWiseAccounts(data.Account).Take(data.TopResults).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }
    }
}
