using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public Button restartButton;

    public Button quitButton;
    void Awake()
    {
        restartButton?.onClick.AddListener(() => SceneManager.LoadScene(ApplicationData.MainMenuScene));

        quitButton?.onClick.AddListener(() => Application.Quit());
    }

}
