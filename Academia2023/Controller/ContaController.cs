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
    public class ContaController
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }
        public Conta Conta { get; set; }
        #endregion

        #region CONSTRUTOR
        public ContaController(CrmServiceClient crmServiceClient)
        {
            ServiceClient = crmServiceClient;
            this.Conta = new Conta(ServiceClient);
        }
        #endregion

        public Guid Create(string nomeDaConta, string cnpj, int idade, decimal porcentagem, string nomeCategoria, int tipoDeVenda)
        {
            return Conta.Create(nomeDaConta, cnpj, idade, porcentagem, nomeCategoria, tipoDeVenda);
        }

        public Entity GetContaByCnj(string cnpj)
        {
            return Conta.GetContaByCnj(cnpj);
        }

    }
}
