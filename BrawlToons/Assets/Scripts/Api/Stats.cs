using System.Collections;
using System.Collections.Generic;
using BrawlToonsAPI.Models;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Stats : MonoBehaviour
{

    private const string ApiBaseUrl = "http://localhost:5000/api/player";
    private const string ApiBaseUrlMatches = "http://localhost:5000/api/Matches";
    private const string ApiBaseUrlPc = "http://localhost:5000/api/PlayerCharacter";
    private List<PlayerCharacter> playerCharacterList = new List<PlayerCharacter>();
    public void Start()
    {
        
    }
    public void OnEnterRanking(int playerNum)
    {
        int playerId = playerNum == 1 ? PlayerPrefs.GetInt("IdPlayer1") : PlayerPrefs.GetInt("IdPlayer2");
        playerCharacterList=new List<PlayerCharacter>();
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
                ShowPlayerStats(player);
                Debug.Log($"Id: {player.player_id}");
                Debug.Log($"Games played: {player.games_played}");
            }
            else
            {

                Debug.LogError($"Error: {request.error}");
            }
        }
    }

    public void ShowPlayerStats(BrawlToonsAPI.Models.Player player)
    {
        GameObject playerDataTable = GameObject.Find("playerTable");
        List<GameObject> rows = new List<GameObject>();

        // Recorre todos los hijos y agrega los que se llaman "row"
        foreach (Transform child in playerDataTable.transform)
        {
            if (child.gameObject.name == "row")
            {
                rows.Add(child.gameObject);
                Debug.Log(child);
            }
        }
        foreach (GameObject row in rows)
        {
            foreach (Transform child in row.transform)
            {
                if (child.gameObject.name == "total")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = player.games_played.ToString();
                }
                else if(child.gameObject.name == "wins")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = player.total_wins.ToString();
                }
                else
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = player.total_losses.ToString();
                }
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
                playerCharacterList.Add(playerCharacter);
                Debug.Log($"Player ID: {playerCharacter.player_id}, Character ID: {playerCharacter.character_id}, Wins: {playerCharacter.wins}, Defeats: {playerCharacter.defeats}");
                if(playerCharacterList.Count == 4)
                {
                    ShowPlayerCharStats(playerCharacterList);
                }
            }
            else
            {
                Debug.LogError($"Error: {request.error}");
            }
        }
    }

    public void ShowPlayerCharStats(List<PlayerCharacter> playerChars)
    {
        GameObject playerDataTable = GameObject.Find("playerCharTable");
        List<GameObject> rows = new List<GameObject>();
        int rowNum = 0;
        // Recorre todos los hijos y agrega los que se llaman "row"
        foreach (Transform child in playerDataTable.transform)
        {
            if (child.gameObject.name == "row")
            {
                rows.Add(child.gameObject);
                Debug.Log(child);
            }
        }
        foreach (GameObject row in rows)
        {
            foreach (Transform child in row.transform)
            {
                if (child.gameObject.name == "wins")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = playerChars[rowNum].wins.ToString();
                }
                else if (child.gameObject.name == "losses")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = playerChars[rowNum].defeats.ToString();
                }
            }
            rowNum++;
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
                ShowMatches(matches,playerId);
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

    public void ShowMatches(List<Matches> matchesList, int playerId)
    {
        GameObject playerDataTable = GameObject.Find("matchesTable");
        List<GameObject> rows = new List<GameObject>();
        int rowNum = 0;
        // Recorre todos los hijos y agrega los que se llaman "row"
        foreach (Transform child in playerDataTable.transform)
        {
            if (child.gameObject.name == "row")
            {
                rows.Add(child.gameObject);
                Debug.Log(child);
            }
        }
        foreach (GameObject row in rows)
        {
            foreach (Transform child in row.transform)
            {
                if (child.gameObject.name == "winner")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = matchesList[rowNum].winner_id==playerId? "Yes":"No";
                }
                else if (child.gameObject.name == "rival")
                {
                    int rivalId = matchesList[rowNum].player_1_id == playerId ? playerId : matchesList[rowNum].player_2_id;
                    StartCoroutine(GetRivalName(rivalId,child.gameObject));
                }
                else
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = matchesList[rowNum].date.ToString();
                }
            }
            rowNum++;
        }
    }

    public IEnumerator GetRivalName(int id, GameObject text)
    {

        using (UnityWebRequest request = UnityWebRequest.Get($"{ApiBaseUrl}/GET/{id}"))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                BrawlToonsAPI.Models.Player player = JsonConvert.DeserializeObject<BrawlToonsAPI.Models.Player>(request.downloadHandler.text);
                text.GetComponent<TextMeshProUGUI>().text = player.username;
                
            }
            else
            {

                Debug.LogError($"Error: {request.error}");
            }
        }
    }
}


