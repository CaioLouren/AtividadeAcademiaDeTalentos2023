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
    public class CategoriaController
    {
        #region PROPS
        public CrmServiceClient ServiceClient { get; set; }

        public Categoria Categoria { get; set; }
        #endregion

        #region CONSTRUTOR
        public CategoriaController(CrmServiceClient crmServiceClient)
        {
            ServiceClient = crmServiceClient;
            this.Categoria = new Categoria(ServiceClient);
        }
        #endregion
        public Entity GetCategoryByName(string nomeCategoria)
        {
            return Categoria.GetCategoryByName(nomeCategoria);
        }
    }
}
