using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public List<PlayerScoreData> playerScores;

    public List<string> winners = new List<string>();

    public List<RuinScript> buildings = new List<RuinScript>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            CalculateScore();
    }

    public void AddToBuildingsList(RuinScript ruin)
    {
        buildings.Add(ruin);
    }

    // Start is called before the first frame update
    public void AddScoreDataToList(PlayerScoreData playerScoreData)
    {
        playerScores.Add(playerScoreData);
    }

    // Update is called once per frame
    public void CalculateScore()
    {
        if(buildings.Count < 1)
        {
            Debug.LogError("Buildings are empty");
        }

        var tempPlayer1Score = 0;
        var tempPlayer2Score = 0;
        var tempPlayer3Score = 0;
        var tempPlayer4Score = 0;

        foreach (var item in buildings)
        {
            switch (item.owningPlayer)
            {
                case RuinScript.Players.P1:
                    tempPlayer1Score++;
                    break;
                case RuinScript.Players.P2:
                    tempPlayer2Score++;
                    break;
                case RuinScript.Players.P3:
                    tempPlayer3Score++;
                    break;
                case RuinScript.Players.P4:
                    tempPlayer4Score++;
                    break;
            }
        }

        foreach(var playerData in playerScores)
        {
            switch (playerData.playerNum)
            {
                case 1:
                    playerData.score = tempPlayer1Score;
                    break;
                case 2:
                    playerData.score = tempPlayer2Score;
                    break;
                case 3:
                    playerData.score = tempPlayer3Score;
                    break;
                case 4:
                    playerData.score = tempPlayer4Score;
                    break;
            }
        }
    }
}
