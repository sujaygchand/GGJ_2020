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
        SpawnRuins();

        if (ruins.Count < 1)
        {
            Debug.LogError("ruins array is empty");
            return;
        }

    }

    // Update is called once per frame
    private void SpawnRuins()
    {
        ruinSpawnPoints = ruinSpawnPoints.OrderBy(spawnPoint => Random.value).ToList();
    }
}
