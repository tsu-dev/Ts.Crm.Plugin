using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;

namespace Ts.Crm.Plugin.Base
{
    public class CrmObj
    {
        public IPluginExecutionContext Context {get;set;}
        public IOrganizationServiceFactory Factory { get; set; }
        public IOrganizationService OrgService { get; set; }
        public ITracingService TracingService { get; set; }
    }
}
