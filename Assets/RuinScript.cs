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
    
    public GameObject Particles;
    public GameObject House;
  

    bool Housebuilt; 


    public static string PSP1 = "Interact_P1";
    public static string PSP2 = "Interact_P2";
    public static string PSP3 = "Interact_P3";
    public static string PSP4 = "Interact_P4";

    public int GridX;
    public int GridY;

    private ScoreManager scoreManager;

    public enum Players {P1, P2,P3,P4, NONE }
    Players player;
    public int CURRENT_PLAYER;
    Vector3 InitialHousePosition;

    public Players CurrentPlayer;// { get; set; }
    
    //players can build and break separately


    void Start()
    {
        scoreManager = scoreManager ?? FindObjectOfType<ScoreManager>();

        player = Players.NONE;
        CurrentPlayer = Players.NONE;

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

        InitialHousePosition = House.transform.position;
        Housebuilt = false;
    }

    // Update is called once per frame
    void Update()
    {

        Rebuild();                   // the function that looks at literally rebuilding the ruin 
        DestroyBuilding();           // the function that looks at literally destroying buildings on the ruin 
       

    }

   

 
    private void Rebuild()
    {
        if (BeingRebuilt == true && Housebuilt == false)              //only triggers when someones interacted with the ruin
        {

            //BUILD!!!!!!!!!!
            RebuildTime = RebuildTime - Time.deltaTime;

            //building
            House.transform.position = new Vector3(House.transform.position.x, House.transform.position.y + 0.004f, House.transform.position.z);

            if (RebuildTime<=0)
            {
                BeingRebuilt = false;                   //once the rebuilt time is depleted, its false
                RebuildTime = TotalReBuiltTime;         //resets the rebuild time

                CurrentPlayer = player;

                Housebuilt = true;

                scoreManager?.CalculateScore();

            }
        }

    }

    private void DestroyBuilding()
    {
        if (Housebuilt == true)              //only triggers when someones interacted with the ruin
        {
            //DESTROY!!!!!!!!!!
            if (player == Players.NONE)
            {
                DestructionTime = DestructionTime - Time.deltaTime;

                //building
                House.transform.position = new Vector3(House.transform.position.x, House.transform.position.y - 0.005f, House.transform.position.z);

                if (DestructionTime <= 0)
                {
                    BeingRebuilt = false;
                    DestructionTime = TotalDestructionTime;         //resets the rebuild time

                    GameObject p = Instantiate<GameObject>(Particles, transform.position, Quaternion.identity);

                    //Particles.Play();

                    //house has sunk underneath
                    House.transform.position = InitialHousePosition;
                    Housebuilt = false;

                    scoreManager?.CalculateScore();
                }

            }
        }
    }


    public void ClaimRuin(int playerNum)
    {

        if (BeingRebuilt == false)       //can only rebuild if not in the process of being rebuilt, if true give ability to destroy it
        {
            if (Input.GetButtonDown(PSP1) || Input.GetButtonDown(PSP2) || Input.GetButtonDown(PSP3) || Input.GetButtonDown(PSP4))      //X BUTTON
            {

                BeingRebuilt = true;        //triggers this bool, and stops anyone from building

                switch (playerNum)
                {
                    case 1:
                        player = Players.P1;
                    
                        break;
                    case 2:
                        player = Players.P2;
                       
                        break;
                    case 3:
                        player = Players.P3;
                       
                        break;
                    case 4:
                        player = Players.P4;
                      
                        break;
                }
          
            }
        }

       

        
            
                //if (Input.GetButton(PSP1Tear) || Input.GetButton(PSP2Tear) || Input.GetButton(PSP3Tear) || Input.GetButton(PSP4Tear))      //X BUTTON

           if (Input.GetButtonDown(PSP1) || Input.GetButtonDown(PSP2) || Input.GetButtonDown(PSP3) || Input.GetButtonDown(PSP4))      //X BUTTON
           {
                if (Housebuilt == true)
                {
                    BeingRebuilt = false;
                }
                if (BeingRebuilt == false)
                {
                //DESTROY!!!!!!!!!!!!!
                     if (player != CurrentPlayer)
                     {
                         player = Players.NONE;
                         return;
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
        if (player == Players.P1 && Housebuilt == false)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;

                GameObject p=    Instantiate<GameObject>(Particles, transform.position, Quaternion.identity);

               
                //Particles.Play();

                //house has sunk underneath
                House.transform.position = InitialHousePosition;
            }
        }

        if (player == Players.P2 && Housebuilt == false)
        {

            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;

                GameObject p = Instantiate<GameObject>(Particles, transform.position, Quaternion.identity);

                

                // Particles.Play();

                //house has sunk underneath
                House.transform.position = InitialHousePosition;
            }
        }

        if (player == Players.P3 && Housebuilt == false)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;

                GameObject p = Instantiate<GameObject>(Particles, transform.position, Quaternion.identity);

              

                // Particles.Play();

                //house has sunk underneath
                House.transform.position = InitialHousePosition;
            }
        }

        if (player == Players.P4 && Housebuilt == false)
        {
            if (BeingRebuilt == true)
            {
                player = Players.NONE;
                CurrentPlayer = player;
                RebuildTime = TotalReBuiltTime;
                BeingRebuilt = false;

                GameObject p = Instantiate<GameObject>(Particles, transform.position, Quaternion.identity);

               
                //Particles.Play();

                //house has sunk underneath
                House.transform.position = InitialHousePosition;
            }
        }
    }

    
}
