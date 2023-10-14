using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GS.Unitive.Framework.Core;
using GS.Unitive.Framework.Persistent;

namespace Cirno.GS.Injection.Test
{
    public class Program:IAddonActivator
    {
        internal IAddonContext addonContext;
        public void Start(IAddonContext context)
        {
            this.addonContext = context;
            dynamic uiAddon = this.addonContext.
                GetFirstOrDefaultService("GS.Terminal.MainShell", "GS.Terminal.MainShell.Services.UIService");

            uiAddon.RegistBackgroundCommand("0", new Action(delegate {
                uiAddon.ShowPrompt("Fuck GS!!", 10);
            }));

            addonContext.Logger.Info("[INFO] Injection program loaded.");
            
        }

        public void Stop(IAddonContext context)
        {

        }
    }
}
