 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;

    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();

        float yon = Random.Range(0f, 1.0f);
        if(yon < 0.5)
        {
            rb2d.AddForce(new Vector2(Random.Range(-3.5f, -2.0f), Random.Range(-3.5f, -2.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(yon * 10.0f);
        }
        else
        {
            rb2d.AddForce(new Vector2(Random.Range(3.5f, 2.0f), Random.Range(-3.5f, -2.0f)), ForceMode2D.Impulse);
            rb2d.AddTorque(-yon * 10.0f);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Kursun")
        {
            oyunKontrol.AsteroidYokOldu(gameObject);
            AsteroidYokEt();
        }
    }

    public void AsteroidYokEt()
    {
        GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().AsteroidPatlama();
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
