using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learning : MonoBehaviour
{
    
    void Start()
    {
        UzayGemisi gemi1 = new UzayGemisi(Random.Range(80,100));
        UzayGemisi gemi2 = new UzayGemisi(Random.Range(80,100), "Gri");

        gemi1.Yavaslatici();
        gemi2.Yavaslatici();

        Debug.Log(gemi1.MaksimumHiz + " " + gemi2.MaksimumHiz);

        if(gemi1.MaksimumHiz > gemi2.MaksimumHiz)
        {
            Debug.Log("Kazanan Gemi1");
        }else if(gemi2.MaksimumHiz > gemi1.MaksimumHiz)
        {
            Debug.Log("Kazanan Gemi2");
        }
        else
        {
            Debug.Log("Berabere");
        }


        //int yokEdilenAstroid = 5;
        //if(yokEdilenAstroid >= 20)
        //{
        //    Debug.Log("win");
        //}
    }

    
    void Update()
    {
        
    }
}
