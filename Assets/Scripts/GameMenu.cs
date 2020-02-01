using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public PlayerScoreData player1ScoreData;
    public PlayerScoreData player2ScoreData;
    public PlayerScoreData player3ScoreData;
    public PlayerScoreData player4ScoreData;

    // Start is called before the first frame update
    void Start()
    {
            player1ScoreData.gameObject.SetActive(ApplicationData.NumOfPlayers >= 1);

            player2ScoreData.gameObject.SetActive(ApplicationData.NumOfPlayers >= 2);

            player3ScoreData.gameObject.SetActive(ApplicationData.NumOfPlayers >= 3);

            player4ScoreData.gameObject.SetActive(ApplicationData.NumOfPlayers >= 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
