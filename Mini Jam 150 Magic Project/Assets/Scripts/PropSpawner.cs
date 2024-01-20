using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public List<GameObject> propSpawnPoints;
    public List<GameObject> propPrefabs;

    void Start()
    {
        SpawnProps();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps()
    {
        foreach(GameObject sp in propSpawnPoints)
        {
            int randNumber = Random.Range(0, propPrefabs.Count);
            GameObject prop = Instantiate(propPrefabs[randNumber], sp.transform.position, Quaternion.identity);
            prop.transform.parent = sp.transform;
        }
    }
}
