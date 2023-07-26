using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Text;

public static class APIHandler
{
    private const string url = "https://localhost:7212/";

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

    public static IEnumerator PostEnemy(Enemy enemy)
    {
        string endpoint = "api/Enemy";
        EnemyDTO enemyToPost = new EnemyDTO(enemy.EnemyName, enemy.EnemyHealth, enemy.EnemyDamage);
        string jsonData = JsonConvert.SerializeObject(enemyToPost);

        // Convert the JSON data to a byte array
        byte[] postData = Encoding.UTF8.GetBytes(jsonData);

        // Create the UnityWebRequest object with the complete URL
        UnityWebRequest request = UnityWebRequest.Post(url + endpoint, jsonData);
        request.SetRequestHeader("Content-Type", "application/json; charset=utf-8");

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error sending POST request: " + request.error);
        }
        else
        {
            // Request successful, handle the response data
            string responseJson = request.downloadHandler.text;
            Debug.Log("Response: " + responseJson);
        }
    }
}
