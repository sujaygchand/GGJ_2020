using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField]
    private string currentPlayers;
    public Dropdown dropdown;

    /*
    private int foo;

   public int Foo { 
        get => foo; 
        set => foo = Mathf.Clamp(value, 0, 4);
    }*/

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

        ApplicationData.NumOfPlayers = Mathf.Clamp(playerValue + 2, 2, 4);
    }
}
