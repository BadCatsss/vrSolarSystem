using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsScripts : MonoBehaviour, IEnumerable
{ // отвечает за генерацию астероидов
   public Rigidbody AsteroidRigidbody;
    // Use this for initialization
    void Start()
    {
        AsteroidRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Instantiate(AsteroidRigidbody);

    }

    

    IEnumerator IEnumerable.GetEnumerator()// с интервалом в 30 с
    {
        yield return new WaitForSeconds(30);
    }
}