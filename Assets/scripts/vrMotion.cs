using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrMotion : MonoBehaviour {
    public Transform MainCameraTransform;
  public static  int COUNT = 0;
   public static Vector3 tr1;
    public static Vector3 tr;
    //отвечает за вращение прицела
    // Use this for initialization
    void Start () {
       
    }
   
    // Update is called once per frame
    void Update () {
        COUNT = 0;
    }
    
    void RotAin()
    {
        if (tr!=tr1)
        {
            COUNT++;
        }
        tr = gameObject.transform.position;
        int x = 1;
        if (x==1)
        {
  tr1=gameObject.transform.position = new Vector3(transform.rotation.w, transform.rotation.w, gameObject.transform.position.z);
            x++;
        }
        else
        {
            gameObject.transform.position = new Vector3(transform.rotation.w, gameObject.transform.rotation.y, gameObject.transform.position.z);
        }
       
    }
    
}
