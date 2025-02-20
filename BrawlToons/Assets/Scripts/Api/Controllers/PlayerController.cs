using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
//referencia a los modelos
using BrawlToonsAPI.Models;

public class PlayerController : MonoBehaviour
{
    //url básica de la api
    private const string ApiBaseUrl = "http://localhost:5000/api/player";
    public string requestAnswer;
    public bool reqSucces=false;
    public BrawlToonsAPI.Models.Player reqPlayer;
    //funciones para llamar a las corrutinas
    public void GetPlayerFunc(int id)
    {
        StartCoroutine(GetPlayer(id));
        
    }

    public void PostPlayerFunc(BrawlToonsAPI.Models.Player player)
    {
        
        StartCoroutine(AddPlayer(player));

    }

    public void UpdatePlayerFunc(BrawlToonsAPI.Models.Player player)
    {
        StartCoroutine(UpdatePlayer(player));
    }

    public void VerifyUserFunc(string username, string passwd)
    {
        StartCoroutine(VerifyUser(username, passwd));
    }
    // Implementa endpoint GET: api/player/GET/{id}
    public IEnumerator GetPlayer(int id)
    {
        Debug.Log("aaa");
        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrl}/GET/{id}"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                BrawlToonsAPI.Models.Player player = JsonConvert.DeserializeObject<BrawlToonsAPI.Models.Player>(request.downloadHandler.text);
                Debug.Log($"Id: {player.player_id}");
                Debug.Log($"Games played: {player.games_played}");
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }

    // Implementa endpoint POST: api/player
    public IEnumerator AddPlayer(BrawlToonsAPI.Models.Player player)
    {
        string jsonData = JsonConvert.SerializeObject(player);
        using (UnityWebRequest request = new UnityWebRequest(ApiBaseUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                BrawlToonsAPI.Models.Player createdPlayer = JsonConvert.DeserializeObject<BrawlToonsAPI.Models.Player>(request.downloadHandler.text);
                Debug.Log(createdPlayer);
                reqPlayer = createdPlayer;
                reqSucces=true;
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
                reqSucces = false;
            }
        }
    }

    // Implementa endpoint GET: api/player/GET/{username},{password}
    public IEnumerator VerifyUser(string username, string password)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrl}/GET/{username},{password}"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                BrawlToonsAPI.Models.Player player = JsonConvert.DeserializeObject<BrawlToonsAPI.Models.Player>(request.downloadHandler.text);
                reqPlayer= player;
                Debug.Log("Todo Bien");
                reqSucces=true;
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
                reqSucces = false;
            }
        }
    }

    // Implementa endpoint PUT: api/player/UPDATE
    public IEnumerator UpdatePlayer(BrawlToonsAPI.Models.Player player)
    {
        string jsonData = JsonConvert.SerializeObject(player);
        using (UnityWebRequest request = new UnityWebRequest($"{ApiBaseUrl}/UPDATE", "PUT"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }
}
