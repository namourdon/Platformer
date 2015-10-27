using UnityEngine;
using System.Collections;

public class GroundSpawn : MonoBehaviour {
    //public variables
    public int maxGround = 20;
    public GameObject ground;
    public float hMin = 6.5f;
    public float hMax = 14f;
    public float vMin = -6f;
    public float vMax = 6f;

    //private variable
    private Vector2 originPosition;

	// Use this for initialization
	void Start () {
        Spawn();
        originPosition = transform.position;
	
	}
    void Spawn()
    {
        for (int i = 0; i < maxGround; i++) 
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(hMin, hMax), Random.Range(vMin, vMax));
            Instantiate(ground, randomPosition,Quaternion.identity);
            originPosition = randomPosition;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
