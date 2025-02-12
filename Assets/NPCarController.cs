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
        //przesu� samoch�d w ty�
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        //odejmij czas tej klatki od czasu �ycia 
        timeToDestroy -= Time.deltaTime;
        //je�eli czas �ycia drogi jest mniejszy lub r�wny 0 to zniszcz obiekt (powinien by� poza polem widzenia)
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
