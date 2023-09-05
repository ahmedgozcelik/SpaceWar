using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderBoyYarim;
    float colliderEnYarim;

    void Start()
    {
        // Uzay gemisini hareket ettir.
        // GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse); //AddForce bir cisme kuvvet uygulamak için kullanılan fonksiyon galiba. Force güç demek. force ve mode olmak üzere 2 parametre alır. Buradaki Impulse'a ise itme kuvveti denir. Impulse yerine force denedim hareket etmedi.

        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5,5)), ForceMode2D.Impulse);
        BoxCollider2D collider = GetComponent<BoxCollider2D>();

        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("çarpışma");
    }

    // Update is called once per frame
    void Update()
    {
        // Asteroid mouse imlecini takip etsin 
        /*
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position); // Kamerayı referans alarak oyun dünyasındaki koordinatlara çevirme
        transform.position = position;
        EkrandaKal();
        */
    }


    // Objenin oyun ekranında kalmasını sağlar. Mause x ekseninde devam etse de obje kesinlikle sınırlar içerisinde kalmasını sağlıyor. ??
    void EkrandaKal()
    {
        Vector3 position = transform.position;
        if (position.x - colliderEnYarim < EkranHesaplayicisi.Sol)
        {
            position.x = EkranHesaplayicisi.Sol + colliderEnYarim;
        }
        else if (position.x + colliderEnYarim > EkranHesaplayicisi.Sag)
        {
            position.x = EkranHesaplayicisi.Sag - colliderEnYarim;
        }
        if (position.y + colliderBoyYarim > EkranHesaplayicisi.Ust)
        {
            position.y = EkranHesaplayicisi.Ust - colliderBoyYarim;
        }
        else if (position.y - colliderBoyYarim < EkranHesaplayicisi.Alt)
        {
            position.y = EkranHesaplayicisi.Alt + colliderBoyYarim;
        }


        transform.position = position;
    }
}
