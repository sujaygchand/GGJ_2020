using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<RuinScript> ruins;
    public List<RuinSpawnPoint> ruinSpawnPoints;
    public int ruinsToSpawn;

    // Start is called before the first frame update
    void Awake()
    {
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

        SpawnRuins();

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
            tempRuin.GridX = ruinSpawnPoint.gridX;
            tempRuin.GridY = ruinSpawnPoint.gridY;
            ruinSpawnPoint.isAvaliable = false;

        }
    }
}
