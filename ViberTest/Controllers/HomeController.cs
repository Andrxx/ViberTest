using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        ViberRequests vr = new ViberRequests();
        string vbToken = "4acbce3d2567d680-2b47e9fc1afd1297-aace9bf974f27814";
        Sender sender = new Sender { name = "Ковалев", avatar = "" };
        public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        {  
            //string sethook = await vr.GetWebhook(vbToken, "https://yourchat.io/");
            //bool delhook = await vr.RemoveWebhook(vbToken, "https://yourchat.io/");  
           
            //string broadcast = await vr.SendBroadcastMessage(vbToken, "https://yourchat.io/", usersID, sender, "broadcast");
            //string info = await vr.GetAccountInfo(vbToken, "https://yourchat.io/");
            //string userInfo = await vr.GetUserInfo(vbToken, "https://yourchat.io/", "1Xyc2cGDSAi2nMbUjyhr6w==");
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> GetWebhookAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            string _botUri = Request.Form["botUri"];
            string sethook = await vr.GetWebhook(_vbToken, _botUri);
            return Json(sethook);
        }

        public async System.Threading.Tasks.Task<ActionResult> DeleteWebhookAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            bool sethook = await vr.RemoveWebhook(_vbToken);
            return Json(sethook);
        }
        public async System.Threading.Tasks.Task<ActionResult> SendMsgAsync()
        {
            string _vbToken = Request.Form["viberToken"];
            string _userID = Request.Form["userID"];
            string _message = Request.Form["msg"];
            Sender _sender = new Sender
            {
                name = Request.Form["sender[name]"],
                avatar = Request.Form["sender[avatar]"]
            };
            
            string msg = await vr.SendMessage(_vbToken, _userID, _sender, _message);
            return Json(msg);
        }

        public async System.Threading.Tasks.Task<ActionResult> SendBroadcastMsgAsync()
        {
            List<string> _usersID = new List<string>();
            _usersID.Add(@"1Xyc2cGDSAi2nMbUjyhr6w==");
            _usersID.Add(@"1Xyc2cGDSAi2nmngUjyhr6w==");
            _usersID.Add(@"1Xydc2cGDSAi2nMbUjydcfw==");
            string _vbToken = Request.Form["viberToken"];
            string _message = Request.Form["msg"];
            Sender _sender = new Sender
            {
                name = Request.Form["sender[name]"],
                avatar = Request.Form["sender[avatar]"]
            };
            
            string msg = await vr.SendBroadcastMessage(_vbToken, _usersID, _sender, _message);
            return Json(msg);
        }

        public async System.Threading.Tasks.Task<ActionResult> TestWebhookAsync()
        {
            //string _vbToken = Request.Form["viberToken"];
            string _botUri = Request.Form["botUri"];
            string _eventType = Request.Form["event"];
            string sethook = await vr.TestBot(_botUri, _eventType);
            return Json(sethook);
        }
    } 
}