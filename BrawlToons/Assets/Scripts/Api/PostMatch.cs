using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrawlToonsAPI.Models;
using Newtonsoft.Json;
using System.Text;
using UnityEngine.Networking;
public class PostMatch : MonoBehaviour
{
    private MatchesController _matchContoller;
    private PlayerCharacterController _playerCharController;
    private PlayerController _playerController;
    private const string ApiBaseUrl = "http://localhost:5000/api/player";
    private const string ApiBaseUrlMatch = "http://localhost:5000/api/Matches";
    private const string ApiBaseUrlPC = "http://localhost:5000/api/PlayerCharacter";
    void Start()
    {

    }

    public void OnFinishMatch(int winnerId)
    {
        Matches match = new Matches()
        {
            match_id = 0,
            player_1_id = PlayerPrefs.GetInt("IdPlayer1", 0),
            player_2_id = PlayerPrefs.GetInt("IdPlayer2", 0),
            winner_id = winnerId,
            date = System.DateTime.Now.Date
        };
        StartCoroutine(AddMatch(match));

        StartCoroutine(GetPlayerToUpdate(match.player_1_id, match.winner_id));
        StartCoroutine(GetPlayerToUpdate(match.player_2_id, match.winner_id));

        StartCoroutine(GetPlayerCharacterStats(PlayerPrefs.GetInt("IdPlayer1"), PlayerPrefs.GetInt("Player1Character"), winnerId));
        StartCoroutine(GetPlayerCharacterStats(PlayerPrefs.GetInt("IdPlayer2"), PlayerPrefs.GetInt("Player2Character"), winnerId));
    }

    public IEnumerator GetPlayerToUpdate(int id, int winnerId)
    {

        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrl}/GET/{id}"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                BrawlToonsAPI.Models.Player player = JsonConvert.DeserializeObject<BrawlToonsAPI.Models.Player>(request.downloadHandler.text);
                player.games_played += 1;
                if (player.player_id == winnerId)
                {
                    player.total_wins += 1;
                }
                else
                {
                    player.total_losses += 1;
                }
                StartCoroutine(UpdatePlayer(player));
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }
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
    private IEnumerator GetPlayerCharacterStats(int playerId, int characterId, int winnerId)
    {

        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrlPC}/GET/{playerId},{characterId}"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                var playerCharacter = JsonConvert.DeserializeObject<PlayerCharacter>(request.downloadHandler.text);
                if (winnerId == playerId)
                {
                    playerCharacter.wins += 1;
                }
                else
                {
                    playerCharacter.defeats += 1;
                }
                StartCoroutine(UpdatePlayerCharacter(playerCharacter));
            }
        }
    }
    private IEnumerator UpdatePlayerCharacter(PlayerCharacter playerCharacter)
    {
        string jsonData = JsonConvert.SerializeObject(playerCharacter);
        using (UnityWebRequest request = new UnityWebRequest($"{ApiBaseUrlPC}/UPDATE", "PUT"))
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

    private IEnumerator AddMatch(Matches match)
    {
        string jsonData = JsonConvert.SerializeObject(match);
        using (UnityWebRequest request = new UnityWebRequest($"{ApiBaseUrlMatch}/PostMatch", "POST"))
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
