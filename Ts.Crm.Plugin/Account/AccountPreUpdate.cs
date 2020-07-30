using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Ts.Crm.Plugin.Base;

namespace Ts.Crm.Plugin.Account
{
    class AccountPreUpdate : IPluginBase, IPlugin
    {
        public override void ExecutePlugin(CrmObj crmObj)
        {
            Entity entity = (Entity)crmObj.Context.InputParameters["Target"];
            if (entity.LogicalName != "account") { return; }
            try
            {

            }
            catch (Exception ex)
            {
                crmObj.TracingService.Trace("AccountPreUpdatePlugin: {0}", ex.ToString());
                throw;
            }
        }
    }
}
