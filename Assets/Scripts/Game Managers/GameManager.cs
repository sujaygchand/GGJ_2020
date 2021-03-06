﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Movement playerPrefab;
    public List<RuinScript> ruins;
    public List<RuinSpawnPoint> ruinSpawnPoints;
    public int ruinsToSpawn;
    public List<PlayerSpawnPoints> playerSpawnPoints;

    private ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        ruinSpawnPoints = FindObjectsOfType<RuinSpawnPoint>().ToList();

        if (ruins.Count < 1)
        {
            Debug.LogError("ruins array is empty");
            return;
        }

        if (ruinSpawnPoints.Count < 1)
        {
            Debug.LogError("ruinSpawnPoints array is empty");
            return;
        }

        scoreManager = FindObjectOfType<ScoreManager>();

        playerSpawnPoints = FindObjectsOfType<PlayerSpawnPoints>().ToList();

        SpawnPlayers();

        SpawnRuins();

    }



    private void SpawnPlayers()
    {
        if (!playerPrefab)
            Debug.LogError("PlayerPrefab is null");

        if(playerSpawnPoints.Count < 3)
            Debug.LogError("Missing a spawn point");

        playerSpawnPoints = playerSpawnPoints.OrderBy(spawnPoint => Random.value).ToList();

        int numOfPlayers = ApplicationData.NumOfPlayers;
        for(int i = 0; i < numOfPlayers; i++)
        {
            var player = Instantiate(playerPrefab, playerSpawnPoints[i].transform);
            player.transform.localPosition = Vector3.zero;
            player.playerNum = i + 1;
            player.IsGameOver = false;
        }
    }

    // Update is called once per frame
    private void SpawnRuins()
    {
        ruinSpawnPoints = ruinSpawnPoints.OrderBy(spawnPoint => Random.value).ToList();
        
        for(int i = 0; i < ruinsToSpawn; i++)
        {
            RuinScript tempRuin = ruins[Random.Range(0, ruins.Count)];

            RuinSpawnPoint ruinSpawnPoint = ruinSpawnPoints.Find(k => k.isAvaliable);

            if (!ruinSpawnPoint)
            {
                Debug.Log("No Ruin Spawn Points are avliable");
                break;
            }
            
            tempRuin = Instantiate(tempRuin, ruinSpawnPoint.transform);
            tempRuin.transform.localPosition = Vector3.zero;
            tempRuin.GridX = ruinSpawnPoint.gridX;
            tempRuin.GridY = ruinSpawnPoint.gridY;
            ruinSpawnPoint.isAvaliable = false;
            scoreManager.AddToBuildingsList(tempRuin);
        }
    }

    public void OnGameFinished()
    {
        StartCoroutine(GoToEndGameScreen());
    }

    private IEnumerator GoToEndGameScreen()
    {

        var players = FindObjectsOfType<Movement>();

        foreach(var player in players)
        {
            player.IsGameOver = true;
        }

        yield return new WaitForSeconds(7f);

        SceneManager.LoadScene(ApplicationData.EndGameScene);
    }
}
