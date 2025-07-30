using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Infra
{
    public class Token
    {
        public async Task GetToken(string username, string password)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://gtm-report-portal.8443.aws-int.thomsonreuters.com/uat/sso/oauth/token");
            request.Headers.Add("Authorization", "Basic dWk6dWltYW4=");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("grant_type", "password"));
            collection.Add(new("username", "aruhela1"));
            collection.Add(new("password", "TGByhn!@55"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}
