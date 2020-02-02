using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    public int timeLimt = 150;
    [SerializeField]
    private float currentTime;
    [SerializeField]
    private int displayTime;
    private bool isGameOver = false;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Awake()
    {
        isGameOver = false;
        currentTime = timeLimt;
        gameManager = gameManager ?? FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;

            if (timerText)
            {
                displayTime = (int)currentTime;
                timerText.text = string.Format("<b>{0}</b>", displayTime);
            }

            if(currentTime <= 0)
            {
                isGameOver = true;
            }
        }
        else
        {
            gameManager.OnGameFinished();
        }
    }
}
