using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    private float verticalSpeed=1;
    private float height=75;
    public Vector3 enePosition;
	// Use this for initialization
	void Start () {
        enePosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        enePosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * height;
        transform.position = enePosition;
	}
}
