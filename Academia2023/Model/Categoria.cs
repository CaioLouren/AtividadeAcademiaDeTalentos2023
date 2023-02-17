using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia2023.Model
{
    public class Categoria
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }
        public String LogicalName { get; set; }
        #endregion

        #region CONSTRUTOR
        public Categoria(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "category";
        }
        #endregion
        private Entity RetrieveOneCategory(QueryExpression queryCategory)
        {
            EntityCollection category = this.ServiceClient.RetrieveMultiple(queryCategory);

            if (category.Entities.Count() > 0)
                return category.Entities.FirstOrDefault();
            else
                Console.WriteLine("Nenhuma conta encontrada com esse nome");

            return null;
        }
        public Entity GetCategoryByName(string nomeCategoria)
        {
            QueryExpression queryCategory = new QueryExpression(this.LogicalName);
            queryCategory.ColumnSet.AddColumns("categoryid");
            queryCategory.Criteria.AddCondition("title", ConditionOperator.Equal, nomeCategoria);
            return RetrieveOneCategory(queryCategory);
        }
    }
}
