using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab;

    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();
    List<GameObject> asteroidList = new List<GameObject>();
    GameObject uzayGemisi;

    [SerializeField]
    int zorluk = 1;
    [SerializeField]
    int carpan = 5;

    UIKontrol uiKontrol;

    // Start is called before the first frame update
    void Start()
    {
        uiKontrol = GetComponent<UIKontrol>();
    }

    public void OyunuBaslat()
    {
        uiKontrol.OyunBasladi();
        uzayGemisi = Instantiate(uzayGemisiPrefab);
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayicisi.Alt + 1, 5f);
        AsteroidUret(5);
    }

    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++)
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            // Bu bölümde üretilmesini istediðimiz asterýidlerin ekranýn üstünde üretilmesini istiyoruz.
            position.x = Random.Range(EkranHesaplayicisi.Sol, EkranHesaplayicisi.Sag);
            position.y = EkranHesaplayicisi.Ust - 1;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, 3)], position, Quaternion.identity);

            asteroidList.Add(asteroid);
        }
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
        uiKontrol.AsteroidYokOldu(asteroid);
        asteroidList.Remove(asteroid);
        if(asteroidList.Count <= zorluk)
        {
            zorluk++;
            AsteroidUret(zorluk * carpan); ;
        }
    }

    public void OyunuBitir()
    {
        foreach(GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt();
        }
        asteroidList.Clear();
        zorluk = 1;
        uiKontrol.OyunBitti();
    }
}
