using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinScript : MonoBehaviour
{

    public float RebuildTime;
    public string PSP1;
    public string PSP2;
    public string PSP3;
    public string PSP4;
    public int GridX;
    public int GridY;

    // Start is called before the first frame update
    void Start()
    {
        if(RebuildTime==0)
        {
            RebuildTime = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Rebuild()
    {
        if(Input.GetButton(PSP1) || Input.GetButton(PSP2)|| Input.GetButton(PSP3)|| Input.GetButton(PSP4))      //X BUTTON
        {
           


        }
    }

}
