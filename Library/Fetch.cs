using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CollageProj
{
    



    public class Fetch
    {
        public static async Task<List<string>> GetDataFromHttp()
        {
            var client = new HttpClient();
            var Subjects = await client.GetFromJsonAsync<List<string>>("https://raw.githubusercontent.com/chyld/datasets/main/subjects.json");
        
            return Subjects;      

        }
    }
}
