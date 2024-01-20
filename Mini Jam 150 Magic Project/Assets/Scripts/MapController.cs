using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    Vector3 playerLastPosition;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDistance; //maximum optimization distance
    float opDistance;
    float opCooldown;
    public float opCooldownDuration;


    void Start()
    {
        playerLastPosition = player.transform.position;
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

        Vector3 moveDirection = player.transform.position - playerLastPosition;
        playerLastPosition = player.transform.position;

        string directionName = GetDirectionName(moveDirection);

        CheckAndSpawnChunk(directionName);

        //check directions for diagonal chunks
        if(directionName.Contains("Up"))
        {
            CheckAndSpawnChunk("Up");
            CheckAndSpawnChunk("Left Up");
            CheckAndSpawnChunk("Right Up");
        }
        if(directionName.Contains("Down"))
        {
            CheckAndSpawnChunk("Down");
            CheckAndSpawnChunk("Left Down");
            CheckAndSpawnChunk("Right Down");
        }
        if(directionName.Contains("Right"))
        {
            CheckAndSpawnChunk("Right");
            CheckAndSpawnChunk("Right Up");
            CheckAndSpawnChunk("Right Down");
        }
        if(directionName.Contains("Left"))
        {
            CheckAndSpawnChunk("Left");
            CheckAndSpawnChunk("Left Up");
            CheckAndSpawnChunk("Left Down");
        }
    }

    void CheckAndSpawnChunk(string direction)
    {
        if(!Physics2D.OverlapCircle(currentChunk.transform.Find(direction).position, checkerRadius, terrainMask))
        {
            SpawnChunk(currentChunk.transform.Find(direction).position);
        }
    }

    string GetDirectionName(Vector3 direction)
    {
        direction = direction.normalized;
        
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            //horizontal more than vertical
            if(direction.y > 0.5f)
            {
                return direction.x > 0 ? "Right Up" : "Left Up";
            }
            else if(direction.y < -0.5)
            {
                return direction.x > 0 ? "Right Down" : "Left Down";
            }
            else
            {
                return direction.x > 0 ? "Right" : "Left";
            }
        }
        else
        {
            //vertical more than horizontal
            if(direction.x > 0.5f)
            {
                return direction.y > 0 ? "Right Up" : "Right Down";
            }
            else if(direction.x < -0.5)
            {
                return direction.y > 0 ? "Left Up" : "Left Down";
            }
            else
            {
                return direction.y > 0 ? "Up" : "Down";
            }
        }
    }

    void SpawnChunk(Vector3 spawnPosition)
    {
        int randNumber = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[randNumber], spawnPosition, Quaternion.identity);
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
