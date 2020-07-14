using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Ts.Crm.Plugin.Base;

//PM command to download SDK
//Install-Package Microsoft.CrmSdk.CoreAssemblies -Version 9.0.2.5
//Push Test

namespace Ts.Crm.Plugin
{
    //Create a note with older address when the address is changed
    public class CreateNote : IPluginBase, IPlugin
    {
        public override void ExecutePlugin(CrmObj crmObj)
        {
            Entity entity = (Entity)crmObj.Context.InputParameters["Target"];
            if (entity.LogicalName != "account") { return; }
            try
            {
                Entity accountPreImage = (Entity)crmObj.Context.PreEntityImages["Image"];
                Entity accountPostImage = (Entity)crmObj.Context.PostEntityImages["Image"];
                if (accountPreImage.Contains("address1_composite") && accountPreImage.Contains("address1_composite"))
                {
                    crmObj.TracingService.Trace("Validating Address Change.");
                    if (accountPreImage.GetAttributeValue<String>("address1_composite") != accountPostImage.GetAttributeValue<String>("address1_composite")
                            && accountPreImage.GetAttributeValue<String>("address1_composite") != null
                            && accountPreImage.GetAttributeValue<String>("address1_composite") != "")
                    {
                        Entity annotation = new Entity("annotation");
                        annotation["objectid"] = new EntityReference(accountPostImage.LogicalName, accountPostImage.Id);
                        annotation["subject"] = "Previous Address:";
                        annotation["notetext"] = accountPreImage["address1_composite"];
                        annotation["objecttypecode"] = accountPostImage.LogicalName;
                        crmObj.TracingService.Trace("AccountPlugin: Updating Note.");
                        crmObj.OrgService.Create(annotation);
                    }
                }
            }
            catch (Exception ex)
            {
                crmObj.TracingService.Trace("AccountPlugin: {0}", ex.ToString());
                throw;
            }
        }
    }
}
