using System;
using UnityEngine;

public partial class BS : MonoBehaviour
{
    //отвечает за проигрование музыки

    int Ver;//вероятность перемешивания песен
    int R; // для расчета вераятности
    int kRAND;//Поле виляющая на Ver зависит от R
    int kCHET;//Поле виляющая на Ver зависит от R
    int J; //Поле для заполнения масива песен
    AudioClip RESULT1;
    AudioClip RESULT2;

    static Array[] MusicARRay;//Массив для музыки
    GameObject[] PlanetsArray;

    AudioSource AudioSssource;// источник звука 
    Boo.Lang.List<GameObject> PlanetsList;// список планет

    Boo.Lang.List<GameObject> VL1;// список для 1 сортировки
    Boo.Lang.List<GameObject> VL2;// список для 2 сортировки

    GameObject[] D_obj;
    GameObject middle;
    GameObject middle1;
    circleScript cs;
    Boo.Lang.List<GameObject> MusicList = new Boo.Lang.List<GameObject>(MusicARRay.Length);//*************
    void Start()
    {
        PlanetScripts P_Scripst = GetComponent<PlanetScripts>();
        D_obj = new GameObject[6];
        PlanetsArray = GameObject.FindGameObjectsWithTag("planet");//масссив планет
        kRAND = UnityEngine.Random.Range(0, 12);
        kCHET = kRAND * 2;
        R = UnityEngine.Random.Range(0, 1);
        MusicARRay = new Array[6];
        cs = new circleScript();
        PlanetsList = new Boo.Lang.List<GameObject>(PlanetsArray.Length);


        for (int J = 0; J < MusicARRay.Length; J++)// заполняем массив песен
        {
            MusicARRay[J] = (AudioClip[])FindObjectsOfTypeIncludingAssets(typeof(AudioClip));
            P_Scripst = PlanetsArray[J].GetComponent<PlanetScripts>();
            P_Scripst.IndexSort = J;


            foreach (var item in MusicList)
            {
                item.AddComponent(MusicARRay[J].GetType());
                D_obj[J] = item;
            }
        }

        ListsADD();
        middle = PlanetsArray[PlanetsArray.Length / 2];//GameObject // находим середину
        middle1 = PlanetsArray[(PlanetsArray.Length / 2) + 1];//GameObject //середина +1











    }

    public void PlaySound(AudioClip Au1, AudioClip Au2)
    {
        Au1 = RESULT1;
        AudioSssource.clip = Au1;
        AudioSssource.Play();
        if (vrMotion.COUNT != 0 && cs.Find_Ob())//vrMotion.COUNT!=0 - сменили положение указателя камеры
        {
            Au2 = RESULT2;
            AudioSssource.clip = Au2;
            AudioSssource.Play();
        }

    }

    public void ListsADD()
    {
        var I_Of_pl = 1;
        var Obj_Of_pl = new GameObject();
        for (int i = 0; i < PlanetsArray.Length; i++)//заполняем список планет
        {
            PlanetsList.Add(PlanetsArray[i]);
            I_Of_pl = PlanetsList.IndexOf(gameObject);
            Obj_Of_pl = PlanetsList[I_Of_pl];
            Obj_Of_pl.AddComponent<AudioSource>();  //***



            foreach (var item in VL1)  //заполняем список VL1

            {
                VL1.Add(PlanetsArray[i]);
                I_Of_pl = PlanetsList.IndexOf(gameObject);
                Obj_Of_pl = PlanetsList[I_Of_pl];
                Obj_Of_pl.AddComponent<AudioSource>();  //***

            }


            foreach (var item in VL2)  //заполняем список VL2

            {
                VL1.Add(PlanetsArray[i]);
                I_Of_pl = PlanetsList.IndexOf(gameObject);
                Obj_Of_pl = PlanetsList[I_Of_pl];
                Obj_Of_pl.AddComponent<AudioSource>();  //***

            }
        }
    }



    private Boo.Lang.List<GameObject> Sort1(GameObject x, GameObject y)
    {


        var X = x.GetComponent<PlanetScripts>();
        var Y = y.GetComponent<PlanetScripts>();
        if (X.IndexSort < Y.IndexSort)
        {
            var Local = VL1.IndexOf(x);
            VL1.Insert(Y.IndexSort, x); // VL1.IndexOf(x)= VL1.IndexOf(y)
            return VL1;

        }

        return VL1;
    }


    private Boo.Lang.List<GameObject> Sort2(GameObject x, GameObject y)
    {
        var X = x.GetComponent<PlanetScripts>();
        var Y = y.GetComponent<PlanetScripts>();

        if (X.IndexSort == Y.IndexSort * 4 || X.IndexSort == Y.IndexSort / 4)// x=4 - т.е y =1 *4 значит x =4 || y=4 - т.е x = 4/4 = 1
        {


            VL2[0].GetComponent<AudioSource>().clip = D_obj[0].GetComponent<AudioClip>();//
            VL2[1].GetComponent<AudioSource>().clip = D_obj[1].GetComponent<AudioClip>();
            VL2[2].GetComponent<AudioSource>().clip = D_obj[2].GetComponent<AudioClip>();
            VL2[3].GetComponent<AudioSource>().clip = D_obj[3].GetComponent<AudioClip>();//
            VL2[4].GetComponent<AudioSource>().clip = D_obj[4].GetComponent<AudioClip>();
            VL2[5].GetComponent<AudioSource>().clip = D_obj[5].GetComponent<AudioClip>();
            return VL2;





        };
        if (X.IndexSort / Y.IndexSort == 2)//6/3
        {
            VL2[0].GetComponent<AudioSource>().clip = D_obj[0].GetComponent<AudioClip>();
            VL2[1].GetComponent<AudioSource>().clip = D_obj[1].GetComponent<AudioClip>();
            VL2[2].GetComponent<AudioSource>().clip = D_obj[2].GetComponent<AudioClip>();//
            VL2[3].GetComponent<AudioSource>().clip = D_obj[3].GetComponent<AudioClip>();
            VL2[4].GetComponent<AudioSource>().clip = D_obj[4].GetComponent<AudioClip>();
            VL2[5].GetComponent<AudioSource>().clip = D_obj[5].GetComponent<AudioClip>();//
            return VL2;

        }

        if (X.IndexSort * Y.IndexSort == 10)//5*2 =10
        {
            VL2[0].GetComponent<AudioSource>().clip = D_obj[0].GetComponent<AudioClip>();
            VL2[1].GetComponent<AudioSource>().clip = D_obj[1].GetComponent<AudioClip>();//
            VL2[2].GetComponent<AudioSource>().clip = D_obj[2].GetComponent<AudioClip>();
            VL2[3].GetComponent<AudioSource>().clip = D_obj[3].GetComponent<AudioClip>();
            VL2[4].GetComponent<AudioSource>().clip = D_obj[4].GetComponent<AudioClip>();//
            VL2[5].GetComponent<AudioSource>().clip = D_obj[5].GetComponent<AudioClip>();
            return VL2;
        }
        return VL2;

    }





    // Update is called once per frame
    void Update()
    {


        if (R == 0)
        {
            Ver = PlanetsList.Count / kCHET; //Ver =12/24
        }
        else if (R == 1)
        {
            Ver = PlanetsList.Count / kRAND; //Ver =12/12
        }

        if (Ver == 0.5) //1/2 или 12/24 - min
        {
            Sort1(middle, middle1);
            foreach (var P in PlanetsList)
            {
                AudioSssource = P.GetComponent<AudioSource>();
                RESULT1 = AudioSssource.clip = VL2[1].GetComponent<AudioClip>();
            }

        }
        if (Ver == 1) //1/2 или 12/12 - max
        {
            Sort2(middle, middle1);
            for (int i = 0; i < PlanetsList.Count; i++)// иттеративно обращаемся к крмпоненту 
            {
                foreach (var P in PlanetsList)
                {
                    AudioSssource = P.GetComponent<AudioSource>();

                    RESULT2 = AudioSssource.clip = VL2[2].GetComponent<AudioClip>();
                }
            }
        }
    }
}










