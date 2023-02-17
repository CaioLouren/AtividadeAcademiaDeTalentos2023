using Academia2023.Controller;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia2023.Model
{
    public class Conta
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }
        public String LogicalName { get; set; }
        #endregion

        #region CONSTRUTOR
        public Conta(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "account";
        }
        #endregion

        public Guid Create(string nomeDaConta, string cnpj, int idade, decimal porcentagem, string nomeCategoria, int tipoDeVenda)
        {
            Entity conta = new Entity(this.LogicalName);
            CategoriaController categoria = new CategoriaController(this.ServiceClient);
            Entity categoriaNome = categoria.GetCategoryByName(nomeCategoria);

            conta["name"] = nomeDaConta;
            conta["acad_cnpj"] = cnpj;
            conta["acad_idadedaconta"] = idade;
            conta["acad_porcentagemdelucro"] = porcentagem;
            conta["acad_categoriadaempresa"] = new EntityReference("category" ,(Guid)categoriaNome["categoryid"]);
            conta["acad_tipodevenda"] = new OptionSetValue(tipoDeVenda);

            Guid accountId = this.ServiceClient.Create(conta);
            return accountId;
        }

        public Entity GetContaByCnj(string cnpj)
        {
            QueryExpression queryAccount = new QueryExpression(this.LogicalName);
            queryAccount.ColumnSet.AddColumns("acad_cnpj", "accountid");
            queryAccount.Criteria.AddCondition("acad_cnpj", ConditionOperator.Equal, cnpj);
            return RetrieveOneConta(queryAccount);
        }

        private Entity RetrieveOneConta(QueryExpression queryAccount)
        {
            EntityCollection accounts = this.ServiceClient.RetrieveMultiple(queryAccount);

            if (accounts.Entities.Count() > 0)
                return accounts.Entities.FirstOrDefault();
            else
                Console.WriteLine("Nenhuma conta encontrada com esse cnpj");

            return null;
        }

    }
}
