using GitApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace GitApi.Controllers
{
    public class GitController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string UserName)
        {
            string auth = "TOKEN";
            GitModel gitModel = new GitModel();
            gitModel.User = GetUser(UserName, auth);
            if(gitModel.User != null)
            {
                gitModel.Repos = GetRepos(gitModel.User.Repos_Url, auth);
            }
            else
            {

                    TempData["Message"] = "User does not exist";
                    return RedirectToAction("index","home");
            }
            return View(gitModel);
        }

        public GitUserModel GetUser(string user,string auth)
        {
            GitUserModel gitUser = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.github.com/users/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitApi", "1.0"));
                var responseTask = client.GetAsync($"{user}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GitUserModel>();
                    readTask.Wait();
                    gitUser = readTask.Result;
                }
                else
                {
                    gitUser = null;
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return gitUser;
        }
        public IEnumerable<RepoModel> GetRepos(string urlname, string auth)
        {
            IEnumerable<RepoModel> repos = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth);
                client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitApi", "1.0"));
                var responseTask = client.GetAsync(urlname);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<RepoModel>>();
                    readTask.Wait();

                    repos = readTask.Result;
                }
                else
                {
                    repos = Enumerable.Empty<RepoModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return repos;
        }
    }
}
