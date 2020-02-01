using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    [SerializeField]
    private Button quitButton;

    private void Awake()
    {
        quitButton = quitButton ?? GetComponent<Button>();

        if (quitButton == null) {
            return;
        }

        quitButton.onClick.AddListener(() => QuitGame());

    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
