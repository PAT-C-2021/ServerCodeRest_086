using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using ServiceRest_20190140086_Abdil_Tegar_Arifin;

namespace ServerCodeRest_20190140086_Abdil_Tegar
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObjek = null;
            Uri address = new Uri("http://localhost:8733/TI_UMY/mex");
            WebHttpBinding binding = new WebHttpBinding();
            try
            {
                hostObjek = new ServiceHost(typeof(TI_UMY), address);
                hostObjek.AddServiceEndpoint(typeof(ITI_UMY), binding, "");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                hostObjek.Description.Behaviors.Add(smb);
                Binding mexBinding = MetadataExchangeBindings.CreateMexHttpBinding();
                hostObjek.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");

                WebHttpBehavior whb = new WebHttpBehavior();
                whb.HelpEnabled = true;
                hostObjek.Description.Endpoints[0].EndpointBehaviors.Add(whb);

                hostObjek.Open();
                Console.WriteLine("Server ready ...");
                Console.ReadLine();
                hostObjek.Close();
            }
            catch (Exception e)
            {
                hostObjek = null;
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
