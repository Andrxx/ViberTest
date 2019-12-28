using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViberTest.BLL;

namespace ViberTest.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        {
            string vbToken = "4acbce3d2567d680-2b47e9fc1afd1297-aace9bf974f27814";
            ViberRequests vr = new ViberRequests();
            //string sethook = await vr.GetWebhook(vbToken, "https://yourchat.io/");
            //bool delhook = await vr.RemoveWebhook(vbToken, "https://yourchat.io/");
            Sender sender = new Sender { name = "Ковалев", avatar = "" };
            //string msg = await vr.SendMessage(vbToken, "https://yourchat.io/", "1Xyc2cGDSAi2nMbUjyhr6w==", sender, "test");
            List<string> usersID = new List<string>();
            usersID.Add( @"1Xyc2cGDSAi2nMbUjyhr6w==");
            usersID.Add(@"1Xyc2cGDSAi2nmngUjyhr6w==");
            usersID.Add(@"1Xydc2cGDSAi2nMbUjydcfw==");
            string broadcast = await vr.SendBroadcastMessage(vbToken, "https://yourchat.io/", usersID, sender, "broadcast");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}