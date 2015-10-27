using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnStart() {
        Application.LoadLevel("Main");
    }
}
