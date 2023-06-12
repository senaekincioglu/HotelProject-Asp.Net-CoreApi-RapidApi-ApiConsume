using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent//Takipçi sayımızı gösterecek.
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/senaekncc"),
                Headers =
    {
        { "X-RapidAPI-Key", "e4335bd6b2mshcbdb3a6ed79bc02p1fbd10jsnc727fb167bda" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
              ResultInstagramFollowersDto resultInstagramFollowersDto=JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);

                ViewBag.v1 = resultInstagramFollowersDto.followers;

                    ViewBag.v2 = resultInstagramFollowersDto.following;

                
            }

            
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=olmedimhalla"),
                Headers =
    {
        { "X-RapidAPI-Key", "e4335bd6b2mshcbdb3a6ed79bc02p1fbd10jsnc727fb167bda" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();

                ResultTwitterFollowersDto resultTwitterFollowersDto=JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(body2);

                ViewBag.v3 = resultTwitterFollowersDto.data.user_info.followers_count;

                ViewBag.v4 = resultTwitterFollowersDto.data.user_info.friends_count;


            }

            
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fsenaekincioglu%2F%3Foriginal_referer%3D%26challengeId%3DAQHYUNgQ77nDBQAAAYiLATlJeb7DEp4g_eSxLvBrejoaUJgh6gjdjtjeeXJFMIuYcxUfQ1Yajmxb0qZHhA9Vu7m8ZVQE-RV2ow%26submissionId%3Df4ff7d5a-0bbb-6517-f52c-941fc42c0c57%26challengeSource%3DAgHk0ive-aoLigAAAYiLAWfYbWcXS5BHEvb70ooQOcFfvZ0aZaOeO6LatQ0J9Ks%26challegeType%3DAgE9ulndnsgy5QAAAYiLAWfc39QcJB7CuVXpV4WJQN5VlFNZZHN2rzw%26memberId%3DAgFbCF5E3MoT0QAAAYiLAWff11FNhIJLSTn7SUk7TahYqA8%26recognizeDevice%3DAgG6ZrWDgVrU2wAAAYiLAWfjc4upJXLuzPVDvZ7-0nB_rP5iNdTg"),
                Headers =
    {
        { "X-RapidAPI-Key", "e4335bd6b2mshcbdb3a6ed79bc02p1fbd10jsnc727fb167bda" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedInFollowersDto resultLinkedInFollowersDto = JsonConvert.DeserializeObject<ResultLinkedInFollowersDto>(body3);
                ViewBag.v5 = resultLinkedInFollowersDto.data.followers_count;
            }

            return View();


        }

    }
}
