using System.Collections;
using System.Collections.Generic;
using BrawlToonsAPI.Models;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Stats : MonoBehaviour
{

    private const string ApiBaseUrl = "http://localhost:5000/api/player";
    private const string ApiBaseUrlMatches = "http://localhost:5000/api/Matches";
    private const string ApiBaseUrlPc = "http://localhost:5000/api/PlayerCharacter";
    public void Start()
    {
        //OnEnterRanking(1);
    }
    public void OnEnterRanking(int playerNum)
    {
        int playerId = playerNum == 1 ? PlayerPrefs.GetInt("IdPlayer1") : PlayerPrefs.GetInt("IdPlayer2");
        StartCoroutine(GetPlayer(playerId));
        for (int i = 0; i < 4; i++)
        {
            StartCoroutine(GetPlayerCharacterStats(playerId, i));
        }
        StartCoroutine(GetLastMatchesCoroutine(playerId));
    }
    public IEnumerator GetPlayer(int id)
    {

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

    private IEnumerator GetPlayerCharacterStats(int playerId, int characterId)
    {
        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrlPc}/GET/{playerId},{characterId}"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                var playerCharacter = JsonConvert.DeserializeObject<PlayerCharacter>(request.downloadHandler.text);
                Debug.Log($"Player ID: {playerCharacter.player_id}, Character ID: {playerCharacter.character_id}, Wins: {playerCharacter.wins}, Defeats: {playerCharacter.defeats}");
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }

    private IEnumerator GetLastMatchesCoroutine(int playerId)
    {
        string url = $"{ApiBaseUrlMatches}/last/{playerId}";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                List<Matches> matches = JsonConvert.DeserializeObject<List<Matches>>(jsonResponse);
                Debug.Log("Últimos 4 partidos recibidos con éxito");

                // Puedes procesar los datos aquí
                foreach (var match in matches)
                {
                    Debug.Log($"Match ID: {match.match_id}, Player1: {match.player_1_id}, Player2: {match.player_2_id}, Winner: {match.winner_id}, Date: {match.date}");
                }
            }
            else
            {
                Debug.LogError($"Error al obtener partidos: {request.error}");
            }
        }
    }
}


