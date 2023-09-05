using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    List<GameObject> asteroidList = new List<GameObject>();

    // asteroidler arrayi oluşturdum 
    //GameObject[] asteroidler = new GameObject[4];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Mouse'nin sol tuşuna basınca aktif olur.
        {
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);

            for (int i = 0; i < 20; i++)
            {
                asteroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity)) ;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //for(int i = 0; i < asteroidList.Count; i++)
            //{
            //    Destroy(asteroidList[i]);
            //}

            foreach(GameObject asteroid in asteroidList)
            {
                Destroy(asteroid);
            }

            asteroidList.Clear();
        }

    }
}
