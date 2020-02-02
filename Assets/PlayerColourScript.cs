using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColourScript : MonoBehaviour
{

    public Material[] PlayerLook;
  
    
    // Start is called before the first frame update
    void Start()
    {
      int ColourNumber = GetComponentInParent<Movement>().playerNum;
        if(ColourNumber==1)
        {
            GetComponent<Renderer>().material = PlayerLook[0];
        }
        if (ColourNumber == 2)
        {
            GetComponent<Renderer>().material = PlayerLook[1];
        }
        if (ColourNumber == 3)
        {
            GetComponent<Renderer>().material = PlayerLook[2];
        }
        if (ColourNumber == 4)
        {
            GetComponent<Renderer>().material = PlayerLook[3];
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
