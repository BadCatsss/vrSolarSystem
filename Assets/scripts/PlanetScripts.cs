using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// отвечает за вращение планет
public class PlanetScripts : MonoBehaviour {
    Transform PlanetTransform;
    public int IndexSort;
 
	// Use this for initialization
	void Start () {
	
        PlanetTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        PlanetTransform.Rotate(new Vector3(transform.position.x,transform.position.y+1,transform.position.z)*Time.deltaTime*0.1f);// поворот вокруг оси
	}
}
