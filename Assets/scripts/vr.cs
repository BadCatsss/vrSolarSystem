using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vr : MonoBehaviour {
   
    void Start () {
        state1 = true;
        Input.gyro.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Input.gyro.attitude *GetRotFix();
        if (state1 == true)// каждый раз когда меняется состояние - выключаем другое и сбрасываем счетчик поворотов
        {
            state2 = false;
            countLandscape = 1;
        }
        else if (state2 == true)
        {
            state1 = false;
            countPortrait = 1;
        }


    }
    bool state1;//горизонтально
    bool state2;//вертикально
    int countLandscape;
    int countPortrait;
    Quaternion GetRotFix()
    {
        // отвечет за вращение поворот и выравнивание камеры
        if (Screen.orientation == ScreenOrientation.Portrait|| Screen.orientation==ScreenOrientation.PortraitUpsideDown && state2==false)//емли телефон не горизонтален
        {
            state2 = true;//телефон повернут вертикально
          
            if (countPortrait==1)
            {
                return Quaternion.Euler(0, 0, 0);
            }
            countPortrait++;
        }

        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight && state1 == true)//если ориеантация устройства изменилась и до этого он был повернут вертикально
        {

            state1 = true;//телефон повернут горизонтально
            if (countLandscape == 1)
            {

                return Quaternion.Euler(Input.gyro.attitude.x, Input.gyro.attitude.y, 90);

               
            }
            countLandscape++;
        }
        //if (Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.Landscape)
        //    return Quaternion.Euler(180, 0, 0);
        
        return Quaternion.identity;


        

        //if (Input.acceleration.y==2|| Input.acceleration.y == -2)
        //{
        //    return Quaternion.Euler(0,0,180);
        //}
    }
}

    




