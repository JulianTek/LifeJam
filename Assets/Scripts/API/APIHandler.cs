using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using Newtonsoft.Json;

public static class APIHandler
{
    private const string url = "https://localhost:7212";

    public static List<EnemyDTO> GetAllEnemies()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}/GetAll");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            var result = JsonConvert.DeserializeObject<APIResult>(json);
        }
        return null;
    }
}
