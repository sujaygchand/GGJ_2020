using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinScript : MonoBehaviour
{

    public float RebuildTime;
    float TotalReBuiltTime;
    bool BeingRebuilt;

    public float DestructionTime;
    float TotalDestructionTime;
   // bool Destroy;

    public static string PSP1 = "Interact_P1";
    public static string PSP2 = "Interact_P2";
    public static string PSP3 = "Interact_P3";
    public static string PSP4 = "Interact_P4";
    public int GridX;
    public int GridY;


    enum Players {P1, P2,P3,P4, NONE }
    Players player;
    Players CurrentPlayer;
    
    //players can build and break separately
    

    void Start()
    {
        player = Players.NONE;

        if (RebuildTime==0)
        {
            RebuildTime = 5;
        }
        TotalReBuiltTime = RebuildTime;



        if (DestructionTime == 0)
        {
            DestructionTime = 5;
        }
        TotalDestructionTime = DestructionTime;

    }

    // Update is called once per frame
    void Update()
    {

        Rebuild();                   // the function that looks at literally rebuilding the ruin 
        DestroyBuilding();           // the function that looks at literally destroying buildings on the ruin 

    }

  
    private void Rebuild()
    {
        if(BeingRebuilt==true)              //only triggers when someones interacted with the ruin
        {

            //BUILD!!!!!!!!!!
            RebuildTime = RebuildTime - Time.deltaTime;
            if (RebuildTime<=0)
            {
                BeingRebuilt = false;                   //once the rebuilt time is depleted, its false
                RebuildTime = TotalReBuiltTime;         //resets the rebuild time
            }
        }

    }

    private void DestroyBuilding()
    {
        if (BeingRebuilt == true)              //only triggers when someones interacted with the ruin
        {

            //DESTROY!!!!!!!!!!
            if (player == Players.NONE)
            {
                DestructionTime = DestructionTime- Time.deltaTime;
                if (DestructionTime<=0)
                {
                    BeingRebuilt = false;
                    DestructionTime = TotalDestructionTime;         //resets the rebuild time

                }


            }

        }
    }


    public void ClaimRuin(int playerNum)
    {

        if (BeingRebuilt == true )       // if in the process of being rebuilt, give ability to destroy it
        {
            if (player != CurrentPlayer)
            {
                if (Input.GetButtonDown(PSP1) || Input.GetButtonDown(PSP2) || Input.GetButtonDown(PSP3) || Input.GetButtonDown(PSP4))      //X BUTTON
                {

                    //DESTROY!!!!!!!!!!!!!

                    player = Players.NONE;
                   
                }
            }
        }



        if (BeingRebuilt == false)       //can only rebuild if not in the process of being rebuilt, if true give ability to destroy it
        {
            if (Input.GetButtonDown(PSP1) || Input.GetButtonDown(PSP2) || Input.GetButtonDown(PSP3) || Input.GetButtonDown(PSP4))      //X BUTTON
            {

                BeingRebuilt = true;        //triggers this bool, and stops anyone from building

                switch (playerNum)
                {
                    case 1:
                        player = Players.P1;
                        CurrentPlayer = player;
                        break;
                    case 2:
                        player = Players.P2;
                        CurrentPlayer = player;
                        break;
                    case 3:
                        player = Players.P3;
                        CurrentPlayer = player;
                        break;
                    case 4:
                        player = Players.P4;
                        CurrentPlayer = player;
                        break;
                }
          
            }
        }

      

    }

    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<Movement>();

        if (!player)
            return;

        ClaimRuin(player.playerNum);
    }


    private void OnTriggerExit(Collider other)
    {
        if (player == Players.P1)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P2)
        {

            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P3)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }

        if (player == Players.P4)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;
            }
        }
    }

    
}
