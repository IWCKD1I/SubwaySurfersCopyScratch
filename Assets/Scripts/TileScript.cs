using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField] GameObject[] groundTile;
    Vector3 nextSpawnPoint;
    public int CoinIndex = 0;
    public void SpawnTile(bool spawnItems)
    {
        int randomIndex = Random.Range(1, groundTile.Length); // Start from index 1 for random selection
        GameObject temp;

        if (nextSpawnPoint == Vector3.zero)
        {
            // For the first tile, use groundTile[0]
            temp = Instantiate(groundTile[0], nextSpawnPoint, Quaternion.identity);
            temp.GetComponent<GroundTile>().SpawnCoins(CoinIndex);
            CoinIndex += 10;
        }
        else
        {
            // For the rest, use a random tile
            temp = Instantiate(groundTile[randomIndex], nextSpawnPoint, Quaternion.identity);
            temp.GetComponent<GroundTile>().SpawnCoins(CoinIndex);
            CoinIndex += 10;
        }
        
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(true);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }
}