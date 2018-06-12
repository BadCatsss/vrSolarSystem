using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vr : MonoBehaviour {
   
    void Start () {
        Horizontal_orint = true;// изначальное предпологаемое сосостояние телефона
        Input.gyro.enabled = true;// включаем гироскоп
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.rotation = Input.gyro.attitude *GetRotFix();
        // код ниже овечает за плавный поворот - без эффекта ориентации устройства
        if (Horizontal_orint == true)// каждый раз когда меняется состояние - выключаем другое и сбрасываем счетчик поворотов
        {
            Vertical_orint = false;
            countLandscape = 1;//сбрасывем счетчик когда изменилось состояние
        }
        else if (Vertical_orint == true)
        {
            Horizontal_orint = false;
            countPortrait = 1;//сбрасывем счетчик когда изменилось состояние
        }


    }

    bool Horizontal_orint;//горизонтально
    bool Vertical_orint;//вертикально
    int countLandscape;
    int countPortrait;

    Quaternion GetRotFix()
    {
        // отвечет за вращение поворот и выравнивание камеры
        if (Screen.orientation == ScreenOrientation.Portrait|| Screen.orientation==ScreenOrientation.PortraitUpsideDown && Vertical_orint == false)//емли телефон не горизонтален
        {
            Vertical_orint = true;//телефон повернут вертикально(выше сбрасывется счетчик countPortrait до 1 )

            if (countPortrait==1)
            {
                return Quaternion.Euler(0, 0, 0);
            }
            countPortrait++;// меняем значение счетчика, что бы указать что сейчас телефон и так в вертикальном положении положении и блок if выше - большене выполнялся
        }
        // ниже идет проверка - если ориеантация устройства изменилась и до этого он был повернут вертикально
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight && Horizontal_orint == true) //Horizontal_orint == true изменилась на true значит телефон перевернули из вертикального положения (из состояния  Vertical_orint - которое теперь false)
        {

            Horizontal_orint = true;//телефон повернут горизонтально(выше сбрасывается счетчик  countLandscape до 1)
            if (countLandscape == 1)
            {

                return Quaternion.Euler(Input.gyro.attitude.x, Input.gyro.attitude.y, 90);//Horizontal_orint == true изменилась на true значит телефон перевернули из вертикального положения - значит нужно повернуть камеру на 90


            }
            countLandscape++;// меняем значение счетчика, что бы указать что сейчас телефон и так в горизонтальном положении и блок if выше - большене выполнялся
        }
       
        
        return Quaternion.identity;


        

       
    }
}

    




