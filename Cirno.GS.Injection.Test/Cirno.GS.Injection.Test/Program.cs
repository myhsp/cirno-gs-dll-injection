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
            addonContext.Logger.Info("[Cirno] Injection program loaded.");

            dynamic uiAddon = this.addonContext.
                GetFirstOrDefaultService("GS.Terminal.MainShell", "GS.Terminal.MainShell.Services.UIService");

            IAddon logicShell = AddonRuntime.Instance.GetInstalledAddons()
                .FirstOrDefault((IAddon ss) => ss.SymbolicName == "GS.Terminal.SmartBoard.Logic");

            IAddonContext logicContext = logicShell.Context;

            dynamic bannerMsgCtrl = logicContext.LoadClassInstance("BannerMessageControl", "GS.Terminal.SmartBoard.Logic.Garitures");

            uiAddon.RegistBackgroundCommand("0", new Action(delegate {
                uiAddon.ShowPrompt("Fuck GS!!", 10);
            }));

            dynamic timeLineService = addonContext.GetFirstOrDefaultService("GS.Terminal.TimeLine", "GS.Terminal.TimeLine.Service");

            string msg = "[Test Console] 测试跑马灯控制";
            
            uiAddon.RegistBackgroundCommand("114514", new Action(delegate {
                try
                {
                    timeLineService.CreateTimeLineTask(DateTime.Now, DateTime.Now.AddSeconds(10.0), 1, true,
                    new Action(delegate {
                        bannerMsgCtrl.AddBannerMsg(msg);
                    }), null, null,
                    new Action(delegate {
                        bannerMsgCtrl.RemoveBannerMsg(msg);
                    }), null, null, "BannerMsgTest"
                    );
                }
                catch (Exception)
                {
                    addonContext.Logger.Info("[Cirno] BannerMsg unable to create.");
                }
            }));
            
        }

        public void Stop(IAddonContext context)
        {

        }
    }
}
