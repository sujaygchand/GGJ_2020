using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField]
    private string currentPlayers;
    public Dropdown dropdown; 

    void Awake()
    {
        if (!dropdown)
        {
            Debug.LogError("Dropdown is NULL!!!");
            return;
        }
        dropdown.onValueChanged.AddListener((value) => UpdatePlayerSelect(dropdown.value));

        UpdatePlayerSelect(dropdown.value);
    }

    // Update is called once per frame
    void UpdatePlayerSelect(int playerValue)
    {
        currentPlayers = dropdown.options[playerValue].text;


/*        switch (playerValue)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;

        }*/
    }
}
