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
    public class Contato
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }
        public String LogicalName { get; set; }
        #endregion

        #region CONSTRUTOR
        public Contato(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.LogicalName = "contact";
        }
        #endregion
        public Guid Create(string nomeContato, string cpf, string telefone, Guid accountId)
        {
            Entity contato = new Entity(this.LogicalName);

            contato["firstname"] = nomeContato;
            contato["acad_cpf"] = cpf;
            contato["telephone1"] = telefone;
            contato["parentcustomerid"] = new EntityReference("account", accountId);

            Guid contatoId = this.ServiceClient.Create(contato);
            return contatoId;
        }

        public Entity GetContactByCpf(string cpf)
        {
            QueryExpression queryContact = new QueryExpression(this.LogicalName);
            queryContact.ColumnSet.AddColumns("acad_cpf", "contactid");
            queryContact.Criteria.AddCondition("acad_cpf", ConditionOperator.Equal, cpf);
            return RetrieveOneContact(queryContact);
        }

        private Entity RetrieveOneContact(QueryExpression queryContact)
        {
            EntityCollection contacts = this.ServiceClient.RetrieveMultiple(queryContact);

            if (contacts.Entities.Count() > 0)
                return contacts.Entities.FirstOrDefault();
            else
                Console.WriteLine("Nenhum contato encontrada com esse cpf");

            return null;
        }
    }
}
