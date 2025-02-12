using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCarController : MonoBehaviour
{
    public float speed = 3.0f;
    public float timeToDestroy = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //przesuñ samochód w ty³
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        //odejmij czas tej klatki od czasu ¿ycia 
        timeToDestroy -= Time.deltaTime;
        //je¿eli czas ¿ycia drogi jest mniejszy lub równy 0 to zniszcz obiekt (powinien byæ poza polem widzenia)
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
