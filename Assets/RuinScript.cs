using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinScript : MonoBehaviour
{

    public float RebuildTime;
    float TotalReBuiltTime;
    bool BeingRebuilt;
    public string PSP1;
    public string PSP2;
    public string PSP3;
    public string PSP4;
    public int GridX;
    public int GridY;


    enum Players {P1, P2,P3,P4, NONE }
    Players player;

    //players should stay until buildings rebuilt before moving
    //players can build and break separately


    
    void Start()
    {
        player = Players.NONE;

        if (RebuildTime==0)
        {
            RebuildTime = 5;
        }
        TotalReBuiltTime = RebuildTime;

    }

    // Update is called once per frame
    void Update()
    {

        Rebuild();      // the function that looks at literally rebuilding the ruin 

    }

    private void Rebuild()
    {
        if(BeingRebuilt==true)              //only triggers when someones interacted with the ruin
        {
            RebuildTime = RebuildTime - Time.deltaTime;

            if(RebuildTime<=0)
            {
                BeingRebuilt = false;                   //once the rebuilt time is depleted, its false
                RebuildTime = TotalReBuiltTime;         //resets the rebuild time
            }
        }

    }

    public void ClaimRuin(String PlayerTag)
    {
        if (BeingRebuilt == false)       //can only rebuild if not in the process of being rebuilt, if true give ability to destroy it
        {
            if (Input.GetButton(PSP1) || Input.GetButton(PSP2) || Input.GetButton(PSP3) || Input.GetButton(PSP4))      //X BUTTON
            {

                BeingRebuilt = true;        //triggers this bool, and stops anyone from building

                if (PlayerTag == "Player 1")
                {
                    player = Players.P1;                   
                }

                if (PlayerTag == "Player 2")
                {
                    player = Players.P2;
                }
                if (PlayerTag == "Player 3")
                {
                    player = Players.P3;
                }
                if (PlayerTag == "Player 4")
                {
                    player = Players.P4;
                }

            }
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player 1")
        {

            ClaimRuin("Player 1");

        }

        if (other.gameObject.tag == "Player 2")
        {
            ClaimRuin("Player 2");

        }

        if (other.gameObject.tag == "Player 3")
        {
            ClaimRuin("Player 3");

        }

        if (other.gameObject.tag == "Player 4")
        {
            ClaimRuin("Player 4");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(player == Players.P1)
        { 
            if(BeingRebuilt==true)
            {
                player = Players.NONE;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P2)
        {

            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P3)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P4)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }
    }
}
