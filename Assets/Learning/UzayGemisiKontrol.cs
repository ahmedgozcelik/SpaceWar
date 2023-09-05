using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{
    const float hareketGucu = 500;
    bool topluyor = false;
    GameObject hedef;

    Rigidbody2D myRigidBody2D;
    Toplayici toplayici;
    
    void Start()
    {
        //Hangi componentlere aitler ?
        myRigidBody2D = GetComponent<Rigidbody2D>();
        toplayici = Camera.main.GetComponent<Toplayici>();
        
    }

    /// <summary>
    /// Uzay gemisine tıklayınca çağrılıyor.
    /// </summary>
    void OnMouseDown()
    {
        if (!topluyor)
        {
            GitVeTopla();
        }
    }

    /// <summary>
    /// Uzay gemimiz yıldıza ulaştığı zaman yıldızı yok et.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == hedef)
        {
            toplayici.YildizYokEt(hedef);
            myRigidBody2D.velocity = Vector2.zero; // velocity -> hız demek
            GitVeTopla();
        }
    }
    
    void GitVeTopla() 
    {
        hedef = toplayici.HedefYildiz;
        if(hedef != null)
        {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x - transform.position.x, hedef.transform.position.y - transform.position.y);

            // Vektörel iki noktayı birleştirmesi için Normalini alması gerekiyor.
            gidilecekYer.Normalize();
            myRigidBody2D.AddForce(gidilecekYer * hareketGucu, ForceMode2D.Force);
        }
    }

    void Update()
    {

        //Vector3 position = transform.position;

        //float yatayInput = Input.GetAxis("Horizontal");
        //float dikeyInput = Input.GetAxis("Vertical");

        //if (yatayInput != 0) // Horizontal değerlerine ulaşmak için kullanılır. Değer olarak -1, 1 aldığı için oyuncu tuşlara bastığında -1, 1 olacağı için 0'a eşit olmadığında hareket eder.
        //{
        //    position.x += yatayInput * hareketGucu * Time.deltaTime;
        //}
        //if (dikeyInput != 0)
        //{
        //    position.y += dikeyInput * hareketGucu * Time.deltaTime;
        //}

        //transform.position = position;
    }
}
