using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoadSegmentController : MonoBehaviour
{
    public float speed = 5.0f;
    public float timeToDestroy = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //przesuñ segment drogi w ty³
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        //odejmij czas tej klatki od czasu ¿ycia drogi
        timeToDestroy -= Time.deltaTime;
        //je¿eli czas ¿ycia drogi jest mniejszy lub równy 0 to zniszcz obiekt (powinien byæ poza polem widzenia)
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
