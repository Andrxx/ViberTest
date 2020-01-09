using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ViberTest.BLL
{
    public class ViberRequests
    {
        public async Task<string> GetWebhook(string viberToken, string botUri)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject _jContent = new JObject();
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/set_webhook");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);

            _jContent.Add("url", botUri);
            //_jContent.Add("event_types",);
            _jContent.Add("send_name", true);
            _jContent.Add("send_photo", true);

            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<bool> RemoveWebhook(string viberToken)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject _jContent = new JObject();
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/set_webhook");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);
            _jContent.Add("url", "");
            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return true;
                }
                else return false;
            }
            catch { return false; }
        }

        public async Task<string> SendMessage(string viberToken, string userID, Sender sender, string msg)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject js = new JObject();
            js.Add("name", sender.name);
            js.Add("avatar", sender.avatar);
            JObject _jContent = new JObject();
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/send_message");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);

            _jContent.Add("receiver", userID);
            _jContent.Add("min_api_version", 1);
            _jContent.Add("sender", js);
            _jContent.Add("tracking_data", "tracking data");
            _jContent.Add("type", "text");
            _jContent.Add("text", msg);
            
            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<string> SendBroadcastMessage(string viberToken, List<string> usersID, Sender sender, string msg)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject js = new JObject();
            js.Add("name", sender.name);
            js.Add("avatar", sender.avatar);
            JObject _jContent = new JObject();
            JArray IDs = new JArray();
            foreach(string s in usersID)
            {
                IDs.Add(s);
            }  
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/broadcast_message");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);

            _jContent.Add("broadcast_list", IDs);
            _jContent.Add("tracking_data", "tracking data");
            _jContent.Add("type", "text");
            _jContent.Add("text", msg);

            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<string> GetAccountInfo (string viberToken, string botUri)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject _jContent = new JObject();
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/get_account_info");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);
            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<string> GetUserInfo(string viberToken, string botUri, string userID)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            JObject _jContent = new JObject();
            _request.Headers.Clear();
            _request.RequestUri = new Uri("https://chatapi.viber.com/pa/get_account_info");
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            _request.Headers.Add("X-Viber-Auth-Token", viberToken);
            HttpContent _content = new StringContent(_jContent.ToString());
            _request.Content = _content;
            _jContent.Add("id", userID);
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }

        public async Task<string> TestBot(string botUri, string eventType)
        {
            HttpClient _cient = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage();
            HttpResponseMessage _respond = new HttpResponseMessage();
            _request.Headers.Clear();
            _request.RequestUri = new Uri(botUri);
            _request.Method = HttpMethod.Post;
            _request.Headers.Add("Content", "application/json");
            
            Dictionary<string, string> cont = new Dictionary<string, string>();
            cont.Add("event", eventType);
            cont.Add("timestamp", "1457764197627");
            cont.Add("message_token", "4912661846655238145");
            HttpContent _content = new FormUrlEncodedContent(cont);
            _request.Content = _content;
            try
            {
                _respond = await _cient.SendAsync(_request);
                if (_respond.IsSuccessStatusCode)
                {
                    string AnswerContent = await _respond.Content.ReadAsStringAsync();
                    return AnswerContent;
                }
                else return null;
            }
            catch { return null; }
        }
    }
}