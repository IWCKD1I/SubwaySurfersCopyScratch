using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    TileScript groundSpawner;
    [SerializeField] GameObject coinPrefab;
    List<float> possibleXValues = new List<float> { 0f, -1.7f, 1.7f };
    
    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<TileScript>();
    }
    

    
    public void SpawnCoins (int CoinIndex)
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>(),CoinIndex);
            CoinIndex++;
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider,int i)
    {
        Vector3 point = new Vector3(
            possibleXValues[Random.Range(0,3)],
            0,
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider,i);
        }

        point.z = i;
        return point;
    }


}
