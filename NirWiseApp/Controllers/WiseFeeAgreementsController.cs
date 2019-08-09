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
    public class WiseFeeAgreementsController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public void UpsertAgreement(FeeAgreement feeAgreement)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                repo.UpsertAgreement(feeAgreement);
            }
        }

        [System.Web.Mvc.HttpPost]
        public void BulkUpsertAgreements(List<FeeAgreement> feeAgreements)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                foreach (var feeAgreement in feeAgreements)
                {
                    repo.UpsertAgreement(feeAgreement);
                }
            }
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetAccountsFromAgreementsForAgent(int agentId)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.GetAccountsFromAgreementsForAgent(agentId).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetFeesForAgentAndAccount(int agentId, int accountId)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.GetFeesForAgentAndAccount(agentId, accountId).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetAccountAndAgentNamesForProduct(int productId)
        {
            using (WiseDBContext db = new WiseDBContext())
            {
                var repo = new WiseRepository(db);

                return new JsonResult()
                {
                    Data = repo.GetAccountAndAgentNamesForProduct(productId).ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }
    }
}
