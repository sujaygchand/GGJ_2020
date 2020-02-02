using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button playButton;
    public Button infoButton;
    public Button backButton;
    public Canvas main;
    public Canvas info;
    void Awake()
    {
        if (!playButton)
             Debug.LogError("playButton is not set");

        playButton.onClick.AddListener(() => SceneManager.LoadScene(ApplicationData.GameScene));

        infoButton?.onClick.AddListener(() => InfoButtonPressed());
        backButton?.onClick.AddListener(() => InfoButtonPressed(false));

        InfoButtonPressed(false);
    }

    public void InfoButtonPressed(bool infoPressed = true)
    {
        main.enabled = !infoPressed;
        info.enabled = infoPressed;
    }


}
