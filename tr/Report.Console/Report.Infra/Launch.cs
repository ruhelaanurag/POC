using Report.Models;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Report.Infra
{
    public class Launch
    {
        private static readonly string token = "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3NTI3NDc2MTcsInVzZXJfbmFtZSI6ImFydWhlbGExIiwiYXV0aG9yaXRpZXMiOlsiUk9MRV9VU0VSIl0sImp0aSI6ImNRbVNjSk5EN19TdkFhN1REd3AyT0ZSVm16dyIsImNsaWVudF9pZCI6InVpIiwic2NvcGUiOlsidWkiXX0.HCb8j5uVkCqSElqHY7qZpfGYHH2Nzi1Rc35RV-c9R8Y";
        public async Task<LaunchModel> GetLaunches(string projectname, DateTime starttime)
        {
            // This method would contain logic to retrieve launches.
            // For example, it could call an API or query a database.
            // The implementation details are not provided in the original code snippet.
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://gtm-report-portal.8443.aws-int.thomsonreuters.com/api/v1/");
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            DateTimeOffset dto = new DateTimeOffset(starttime, TimeSpan.Zero);
            var response = await httpClient.GetAsync($"{projectname}/launch?filter.gt.startTime={dto.ToUnixTimeMilliseconds().ToString()}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LaunchModel>(content);
                // Process the content as needed
                //Console.WriteLine(content);
                return result;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            return new LaunchModel(); // Return an empty Rootobject or handle as needed
        }

    }

    public class Item
    {
        private static readonly string token = "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3NTI3NDc2MTcsInVzZXJfbmFtZSI6ImFydWhlbGExIiwiYXV0aG9yaXRpZXMiOlsiUk9MRV9VU0VSIl0sImp0aSI6ImNRbVNjSk5EN19TdkFhN1REd3AyT0ZSVm16dyIsImNsaWVudF9pZCI6InVpIiwic2NvcGUiOlsidWkiXX0.HCb8j5uVkCqSElqHY7qZpfGYHH2Nzi1Rc35RV-c9R8Y";
        public async Task<ItemModel> GetItems(string projectname, int launchid, int pagesize)
        {
            // This method would contain logic to retrieve items.
            // For example, it could call an API or query a database.
            // The implementation details are not provided in the original code snippet.
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://gtm-report-portal.8443.aws-int.thomsonreuters.com/api/v1/");
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            try
            {
                var response = await httpClient.GetAsync($"{projectname}/item?filter.eq.launchId={launchid}&filter.eq.status=failed&page.page=1&page.size=10000");
                    //$"gtm/item?filter.eq.launchId=46055&filter.eq.status=failed&page.page=1&page.size=66");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    File.WriteAllText($"C:\\Users\\c279553\\Downloads\\item_{launchid}.json", content);
                    var result = JsonSerializer.Deserialize<ItemModel>(content);
                    // Process the content as needed
                    //Console.WriteLine(content);
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
            }
            
            return new ItemModel(); // Return an empty Rootobject or handle as needed
        }
    }

    public class Log
    {
        private static readonly string token = "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3NTI3NDc2MTcsInVzZXJfbmFtZSI6ImFydWhlbGExIiwiYXV0aG9yaXRpZXMiOlsiUk9MRV9VU0VSIl0sImp0aSI6ImNRbVNjSk5EN19TdkFhN1REd3AyT0ZSVm16dyIsImNsaWVudF9pZCI6InVpIiwic2NvcGUiOlsidWkiXX0.HCb8j5uVkCqSElqHY7qZpfGYHH2Nzi1Rc35RV-c9R8Y";
        public async Task<LogModel> GetLogs(string projectname, int launchid, int pagesize)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://gtm-report-portal.8443.aws-int.thomsonreuters.com/api/v1/");
            httpClient.DefaultRequestHeaders.Add("Authorization", token);
            var response = await httpClient.GetAsync($"{projectname}/log?filter.eq.launchId={launchid}&filter.eq.status=FAILED&filter.eq.level=error&page.page=1&page.size={10000}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                File.WriteAllText($"C:\\Users\\c279553\\Downloads\\log_{launchid}.json", content);
                var result = JsonSerializer.Deserialize<LogModel>(content);
                // Process the content as needed
                //Console.WriteLine(content);
                return result;
            }
            return new LogModel(); // Return an empty LogModel or handle as needed
        }
    }

    public class Process
    {
        public void RunProcess()
        {
            // This method would contain logic to run a process.
            // For example, it could execute a command or start a service.
            // The implementation details are not provided in the original code snippet.
            Console.WriteLine("Running process...");

        }
    }
}
