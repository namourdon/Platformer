using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDie : MonoBehaviour {
  

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   //pour detruire the joueur
    void OnTriggerEnter2D(Collider2D othher) {
        if (othher.gameObject.CompareTag("Player")) {

            Application.LoadLevel(Application.loadedLevel);
            
        }
    }
}
