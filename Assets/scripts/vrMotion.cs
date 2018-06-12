using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrMotion : MonoBehaviour {
    public Transform MainCameraTransform;// главная камера
  public static  int COUNT = 0;
   public static Vector3 tr1;
    public static Vector3 tr;
    //отвечает за вращение прицела (оранжевой точки) вместе с камерой
    // Use this for initialization
    void Start () {
       
    }
   
    // Update is called once per frame
    void Update () {
        COUNT = 0;// каждый кадр сбрасываем состояние для его изминения в следующем кадре
    }
    
    void RotAin()
    {
        if (tr!=tr1)// если новое положение не совпадает с текущим(пользоатель повернул устройство)
        {
            COUNT++;// увеличиваем счетчик(меняем его состояние ровно на один кадр - в следующем кадре он снова сбросится)
        }
        tr = gameObject.transform.position;// получаем позицию камеры/прицела
        int x = 1; // в данном кадре нужно изменить старую позицию на новую по x  - ровно 1 раз
        if (x==1)
        {
  tr1=gameObject.transform.position = new Vector3(transform.rotation.w, transform.rotation.w, gameObject.transform.position.z);// новая позиция
            x++;//больше не меняем позицию по x в текущем  кадре
        }
        else// после изминения позиции по x (когда x !=1) меняем значение по y
        {
            gameObject.transform.position = new Vector3(transform.rotation.w, gameObject.transform.rotation.y, gameObject.transform.position.z);
        }
       
    }
    
}
