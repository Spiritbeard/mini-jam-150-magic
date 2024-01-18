using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDistance; //maximum optimization distance
    float opDistance;
    float opCooldown;
    public float opCooldownDuration;


    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }

        if(pm.direction.x > 0 && pm.direction.y == 0) //right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x < 0 && pm.direction.y == 0) //left
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x == 0 && pm.direction.y > 0) //up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x == 0 && pm.direction.y < 0) //down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x > 0 && pm.direction.y > 0) //right up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x > 0 && pm.direction.y < 0) //right down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x < 0 && pm.direction.y > 0) //left up
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        else if(pm.direction.x < 0 && pm.direction.y < 0) //left down
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk()
    {
        int randNumber = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[randNumber], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        opCooldown -= Time.deltaTime;
        if(opCooldown < 0f)
        {
            opCooldown = opCooldownDuration;
        }
        else
        {
            return;
        }
        
        foreach(GameObject chunk in spawnedChunks)
        {
            opDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if(opDistance > maxOpDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }    
}
