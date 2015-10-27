using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

    public Transform [] enemySpawn;
    public GameObject enemy;
    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        //pour faire les enemy devenir beaucoup plus
        for (int i = 0; i < enemySpawn.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
            {
                Instantiate(enemy, enemySpawn[i].position, Quaternion.identity);
            }
        }
    }
}
