using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreData : MonoBehaviour
{
    public Text scoreText;
    public int playerNum;
    public int score = 0;
    public ScoreManager scoreManager;

    private void OnEnable()
    {
        scoreText = scoreText ?? GetComponentsInChildren<Text>()[1];

        scoreManager = scoreManager ?? FindObjectOfType<ScoreManager>();
        scoreManager.AddScoreDataToList(this);
    }

    private void LateUpdate()
    {
        if(scoreText)
        scoreText.text = string.Format("<b>{0}</b> ",score);
    }

}
