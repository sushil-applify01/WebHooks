using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Webhook_Test.WebHookHandlers
{
    public class GitHubWebHookHandler: WebHookHandler
    {
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            try
            {
                if ("GitHub".Equals(receiver, StringComparison.CurrentCultureIgnoreCase))
                {
                    string action = context.Actions.First();
                    JObject data = context.GetDataOrDefault<JObject>();
                    var dataAsString = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    File.WriteAllText(@"D:\data.json", dataAsString);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }

        }
    }
}