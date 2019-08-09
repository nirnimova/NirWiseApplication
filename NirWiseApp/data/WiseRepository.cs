using NirWiseApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NirWiseApp.data
{
    public class WiseRepository
    {
        private WiseDBContext db;

        public WiseRepository(WiseDBContext db)
        {
            this.db = db;
        }

        internal IQueryable<Account> SearchWiseAccounts(Account account)
        {
            var filteredAccounts = db.Accounts.AsQueryable();

            if (account.Id > 0)
                filteredAccounts = filteredAccounts.Where(acc => acc.Id == account.Id);

            if (!String.IsNullOrWhiteSpace(account.FirstName))
                filteredAccounts = filteredAccounts.Where(acc => acc.FirstName.Contains(account.FirstName));

            if (!String.IsNullOrWhiteSpace(account.SurName))
                filteredAccounts = filteredAccounts.Where(acc => acc.SurName.Contains(account.SurName));

            if (!String.IsNullOrWhiteSpace(account.City))
                filteredAccounts = filteredAccounts.Where(acc => acc.City.Contains(account.City));

            return filteredAccounts;
        }

        internal IQueryable<Account> GetAccountsFromAgreementsForAgent(int agentId)
        {
            return (from fa in db.FeeAgreements.AsQueryable()
                    join acc in db.Accounts.AsQueryable() on fa.AccountId equals acc.Id
                    select acc).Distinct();
        }

        internal void UpsertAgreement(FeeAgreement feeAgreement)
        {
            if (feeAgreement.Id > 0)
            {
                db.Entry(feeAgreement).State = EntityState.Modified;
            }
            else
            {
                db.FeeAgreements.Add(feeAgreement);
            }

            db.SaveChanges();
        }

        internal IQueryable<ProductsFeesForAgreement> GetFeesForAgentAndAccount(int agentId, int accountId)
        {
            var productsWithAgreements = (from prd in db.Products.AsQueryable()
                                          join fa in db.FeeAgreements.AsQueryable() on prd.Id equals fa.ProductId
                                          where fa.AgentId == agentId
                                          where fa.AccountId == accountId
                                          select new ProductsFeesForAgreement
                                          {
                                              AgreementId = fa.Id,
                                              ProductId = prd.Id,
                                              ProductName = prd.Name,
                                              Fee = fa.Fee,
                                          });

            return (from prd in db.Products.AsQueryable()
                    join pa in productsWithAgreements on prd.Id equals pa.ProductId into pa2prd
                    from paJoined in pa2prd.DefaultIfEmpty()
                    select paJoined ?? new ProductsFeesForAgreement
                    {
                        AgreementId = 0,
                        ProductId = prd.Id,
                        ProductName = prd.Name,
                        Fee = 0,
                    });
        }

        internal IQueryable<AccountAndAgentNamesForProduct> GetAccountAndAgentNamesForProduct(int productId) => (
            from fa in db.FeeAgreements.AsQueryable()
            join agnt in db.Agents on fa.AgentId equals agnt.Id
            join acc in db.Accounts on fa.AccountId equals acc.Id
            where fa.ProductId == productId
            select new AccountAndAgentNamesForProduct
            {
                AccountFirstName = acc.FirstName,
                AccountSurName = acc.SurName,
                AgentFirstName = agnt.FirstName,
                AgentSurName = agnt.SurName,
            });

        internal IQueryable<Agent> SearchWiseAgents(Agent agent)
        {
            var filteredAgents = db.Agents.AsQueryable();

            if (agent.Id > 0)
                filteredAgents = filteredAgents.Where(agnt => agnt.Id == agent.Id);

            if (!String.IsNullOrWhiteSpace(agent.FirstName))
                filteredAgents = filteredAgents.Where(agnt => agnt.FirstName.Contains(agent.FirstName));

            if (!String.IsNullOrWhiteSpace(agent.SurName))
                filteredAgents = filteredAgents.Where(agnt => agnt.SurName.Contains(agent.SurName));

            return filteredAgents;
        }
    }
}