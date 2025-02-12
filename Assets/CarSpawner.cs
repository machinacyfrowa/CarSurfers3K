using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnInterval = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 0, spawnInterval);
    }

    void SpawnCar()
    {
        //losujemy czy siê pojawi w ogóle czy nie
        if (Random.Range(0, 100) > 20)
        {
            //je¿eli losowanie 0-100 da wynik >20 to nie spawnujemy
            return;
        }
        //dostaniemy -2, 0 albo 2
        int randomLane = Random.Range(-1, 2)*2;
        //lokalizacja spawnu
        Vector3 spawnPosition = new Vector3(randomLane, transform.position.y, transform.position.z);
        //sprawdz czy miejsce nie jest ju¿ zajête
        if(Physics.CheckSphere(spawnPosition + Vector3.up, 0.5f))
        {
            //jeœli coœ ju¿ jest to nie spawnuj
            return;
        }
        Instantiate(carPrefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
