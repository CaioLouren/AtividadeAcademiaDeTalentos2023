using Academia2023.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia2023.Controller
{
    public class ContatoController
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }

        public Contato Contato { get; set; }
        #endregion

        #region CONSTRUTOR
        public ContatoController(CrmServiceClient crmServiceClient)
        {
            ServiceClient = crmServiceClient;
            this.Contato = new Contato(ServiceClient);
        }
        #endregion

        public Guid Create(string nomeDoContato, string cpf, string telefone, Guid accountId)
        {
            return Contato.Create(nomeDoContato, cpf, telefone, accountId);
        }
        public Entity GetContactByCpf(string cpf)
        {
            return Contato.GetContactByCpf(cpf);
        }
    }
}
