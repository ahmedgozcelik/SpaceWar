using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] // public olmasını istemediğimiz objelere unityden erişmek için kullanırız. 
    GameObject asteroidPrefab;

    GeriSayimSayaci geriSayimSayaci;

    void Start()
    {
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
        geriSayimSayaci.ToplamSure = 1;
        geriSayimSayaci.Calistir();
    }

    
    void Update()
    {
        if (geriSayimSayaci.Bitti)
        {
            //Spawn Game Object
            SpawnAstreoid();
            geriSayimSayaci.Calistir();
        }
    }

    void SpawnAstreoid()
    {
        Instantiate(asteroidPrefab);
    }
}
