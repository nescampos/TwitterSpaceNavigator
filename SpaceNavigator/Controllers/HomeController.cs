using Microsoft.AspNetCore.Mvc;
using SpaceNavigator.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace SpaceNavigator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(IndexNavigatorFormModel Form)
        {
            IndexNavigatorViewModel model = new IndexNavigatorViewModel();
            model.Form = Form;
            if(!string.IsNullOrEmpty(Form.Title))
            {
                string isLive = Form.IsLive.HasValue ? (Form.IsLive.Value? "&state=live" : "&state=scheduled") : "&state=all";
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("https://api.twitter.com/");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _configuration["TwitterBearerToken"]);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    model.Response = await httpClient.GetFromJsonAsync<TwitterSpaceDetail>("2/spaces/search?query="+ Form.Title + "&space.fields=lang%2Chost_ids%2Cis_ticketed%2Ccreator_id%2Cstate%2Ccreated_at%2Cended_at%2Cid%2Cinvited_user_ids%2Cparticipant_count%2Cscheduled_start%2Cspeaker_ids%2Cstarted_at%2Csubscriber_count%2Ctitle%2Ctopic_ids%2Cupdated_at&expansions=&user.fields=name%2Cprofile_image_url%2Cusername%2Cid&topic.fields=name%2Cid&max_results=100"+ isLive);
                    if (model.Response != null && model.Response.data != null)
                    {
                        model.Response.data = model.Response.data.OrderBy(x => x.started_at).ThenBy(x => x.scheduled_start).ToList();
                    }
                    if (Form.Language != null && model.Response != null && model.Response.data != null)
                    {
                        model.Response.data = model.Response.data.Where(x => x.lang == Form.Language).ToList();
                    }
                    
                    return View(model);
                }
            }
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}