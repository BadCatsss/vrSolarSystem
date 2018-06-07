using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour {
    // отвечает за удаление астероидов
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Asteroid 1"|| col.gameObject.name == "Asteroid 2"|| col.gameObject.name == "Asteroid 3")
        {
            Destroy(col.gameObject);
        }
    }
}
