using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button playButton;

    void Awake()
    {
        if (!playButton)
            Debug.LogError("playButton is not set");

        playButton.onClick.AddListener(() => SceneManager.LoadScene(ApplicationData.GameScene));
    }

}
