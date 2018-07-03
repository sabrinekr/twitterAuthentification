using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp;

namespace login33.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpGet]
        public ActionResult TwitterAuth()
        {
            string Key = "OK4w6I5Gp9Fjl8SCQflxOvQJK";
            string Secret = "Cjh7cr3R79SAClRGkennpfRYQjtP62tf8hYrOYXKCQPzfztE0P";


            TwitterService service = new TwitterService(Key, Secret);

            OAuthRequestToken requestToken = service.GetRequestToken("http://localhost:58190/Home/TwitterCallback");

            Uri uri = service.GetAuthenticationUrl(requestToken);

            return Redirect(uri.ToString());
        }
        public ActionResult TwitterCallback(string oauth_token, string oauth_verifier)
        {
            var requestToken = new OAuthRequestToken { Token = oauth_token };

            string Key = "OK4w6I5Gp9Fjl8SCQflxOvQJK";
            string Secret = "Cjh7cr3R79SAClRGkennpfRYQjtP62tf8hYrOYXKCQPzfztE0P";

            try
            {
                TwitterService service = new TwitterService(Key, Secret);

                OAuthAccessToken accessToken = service.GetAccessToken(requestToken, oauth_verifier);

                service.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

                VerifyCredentialsOptions option = new VerifyCredentialsOptions();

                TwitterUser user = service.VerifyCredentials(option);
                TempData["Name"] = user.Name;
                TempData["Userpic"] = user.ProfileImageUrl;

                return View();
            }
            catch
            {
                throw;
            }

        }

    }
}