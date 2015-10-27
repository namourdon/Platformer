using UnityEngine;
using System.Collections;

public class CoinSpawn : MonoBehaviour {

    public Transform[] coinSpawn;
    public GameObject coin;
	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Spawn () {
        //pour faire les coins devenir beaucoup plus
        for (int i = 0; i < coinSpawn.Length; i++) 
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0) 
            {
                Instantiate(coin, coinSpawn[i].position, Quaternion.identity);
            }
        }
	}
}
