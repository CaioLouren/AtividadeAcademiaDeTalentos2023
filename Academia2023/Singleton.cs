using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia2023.AlfaPeople.ConsoleApplication
{
    public class Singleton
    {
        public static CrmServiceClient GetService()
        {
            String url = "org7a3e2452";
            String clientId = "25b1fa6b-eb76-48aa-905a-0c2afd182b6b";
            String clientSecret = "_eY8Q~06daXdXw-6Pg~z-q3JS0HezsVBIcGJibO4";

            CrmServiceClient serviceClient = new CrmServiceClient($"AuthType=ClientSecret;Url=https://{url}.crm2.dynamics.com/;AppId={clientId};ClientSecret={clientSecret};");

            if (!serviceClient.CurrentAccessToken.Equals(null))
                Console.WriteLine("Conexão realizada com sucesso");
            else
                Console.WriteLine("Error na conexão");

            return serviceClient;
        }
    }
}