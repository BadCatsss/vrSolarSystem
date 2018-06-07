using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleScript : MonoBehaviour
{
    // отвечает за определение направления взгляда - поиск объекта на который смотрят
    Object[] array;
    BS bs = new BS();
   static AudioClip au1_C = null;
  static  AudioClip au2_C = null;
    Camera MainCamera;
    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
      Object[]  array = FindObjectsOfTypeIncludingAssets(typeof(BS));
    }

    // Update is called once per frame
    void Update()
    {
        Find_Ob();
    }

   public   bool Find_Ob()
    {
        AudioSource MainCameraClip = MainCamera.GetComponent<AudioSource>();
        for (int i = 0; i < array.Length; i++)
        {
            if ((Physics.Raycast(new Ray(new Vector3( transform.position.x, transform.position.y), new Vector3(transform.position.x, transform.position.y)))) == array[i])
            {
                bs.PlaySound(MainCameraClip.clip = au1_C, MainCameraClip.clip = au2_C);
              
               
                return true;
            }
            else
            {
                return false;
            }
        }


        return true;

    }
}
