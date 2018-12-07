using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Ts.Crm.Plugin.Base
{
    public abstract class IPluginBase : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var crmObj = new CrmObj();
            crmObj.Context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            crmObj.Factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            crmObj.OrgService = crmObj.Factory.CreateOrganizationService(crmObj.Context.UserId);
            crmObj.TracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            if (crmObj.Context.InputParameters != null && crmObj.Context.InputParameters["Target"] is Entity)
            {
                this.ExecutePlugin(crmObj);
            }
        }
        public abstract void ExecutePlugin(CrmObj crmObj);
    }
}
