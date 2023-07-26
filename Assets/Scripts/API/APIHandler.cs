using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Text;
using System.Linq;

public static class APIHandler
{
    private const string url = "https://localhost:7212/";

    public static List<EnemyDTO> GetAllEnemies()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{url}GetAll");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();
            try
            {
                var result = JsonConvert.DeserializeObject<APIResult>(json);
                if (result != null)
                    return result.value.ToList();
            }
            catch
            {
                return null;
            }

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
        // Create the UnityWebRequest object with the complete URL
        UnityWebRequest request = new UnityWebRequest(url + endpoint, "POST");
        request.uploadHandler = new UploadHandlerRaw(postData);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

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

    public static IEnumerator DeleteAll()
    {
        string endpoint = "DeleteAll";

        UnityWebRequest request = UnityWebRequest.Delete(url + endpoint);
        request.downloadHandler = new DownloadHandlerBuffer();

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
