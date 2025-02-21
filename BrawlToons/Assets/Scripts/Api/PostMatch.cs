using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BrawlToonsAPI.Models;
public class PostMatch : MonoBehaviour
{
    private MatchesController _matchContoller;
    private PlayerCharacterController _playerCharController;
    private PlayerController _playerController;
    void Start()
    {
        _matchContoller = GetComponent<MatchesController>();
        _playerController = GetComponent<PlayerController>();
        
    }

    public void OnFinishMatch(int winnerId)
    {
        Matches match = new Matches()
        {
            match_id = 0,
            player_1_id = PlayerPrefs.GetInt("IdPlayer1", 0),
            player_2_id = PlayerPrefs.GetInt("IdPlayer2", 0),
            winner_id = winnerId,
            date = System.DateTime.Now
        };
        _matchContoller.PostMatchFunc(match);
        //_playerController.GetPlayer(match.player_1_id);
        //WaitPlayer(winnerId);
        //_playerController.GetPlayer(match.player_2_id);
        //WaitPlayer(winnerId);
    }

    public void UpdatePlayerChar()
    {

    }

    public void UpdatePlayer(int winnerId, int idPlayer)
    {
        
    }

    public IEnumerator WaitPlayer(int winnerId)
    {
        yield return new WaitForSeconds(1);
        BrawlToonsAPI.Models.Player playerToUpdate = _playerController.reqPlayer;
        if(playerToUpdate != null)
        {
            if(playerToUpdate.player_id==winnerId)
            {
                playerToUpdate.total_wins += 1;
            }
            else
            {
                playerToUpdate.total_losses += 1;
            }
            _playerController.UpdatePlayer(playerToUpdate);
        }
    }
}
