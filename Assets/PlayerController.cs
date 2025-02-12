using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lane przechowuje wsp�rz�dne x dla konkretnych pas�w drogowych
enum Lane
{
    LEFT = -2,
    CENTER = 0,
    RIGHT = 2
}

public class PlayerController : MonoBehaviour
{
    //docelowy pas na kt�rym jeste�my albo na kt�ry chcemy si� przemie�ci�
    Lane targetLane;
    //zmienna, flaga wskazuj�ca czy aktualnie zmieniamy pas
    bool isMoving;
    //pr�dko�� zmiany pasa
    public float laneChangeSpeed = 5.0f;
    //levelmanager
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        targetLane = Lane.CENTER;
        isMoving = false;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //odbierz stan kontrolera / klawiatury i zapisz do zmiennej
        //zapisujemy ruch lewo prawo, a ignorujemy ruch g�ra d�
        //getaxisraw dzia�a binarnie (-1, 0, 1) - bez u�amk�w
        if (!isMoving)
            GetInput();
        else
            Move(); //je�eli flaga isMoving jest true to wykonaj funkcj� Move

        //Debug.Log("Docelowy pas:" + targetLane);

    }
    void GetInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        //je�eli nie jest nic wci�ni�te to zako�cz funkcj�
        if (input == Vector2.zero)
            return;
        //obecna pozycja samochodu zaokr�glona do liczby ca�kowitej
        int currentLane = (int)transform.position.x;
        //dodaj do obecnej pozycji samochodu warto�� wektora wej�ciowego
        //mo�liwe sytuacje - dodaj -2 przesunie w lewo, dodaj 2 przesunie w prawo
        currentLane += (int)input.x * 2;
        //ograniczenie ruchu do pas�w drogowych
        currentLane = Mathf.Clamp(currentLane, (int)Lane.LEFT, (int)Lane.RIGHT);
        //ustaw docelowy pas
        targetLane = (Lane)currentLane;
        //ustaw flag� ruchu
        isMoving = true;
    }
    void Move()
    {
        //docelowa pozycja to obecna pozycja ze zmienion� osi� x na nowy pas
        Vector3 targetPosition = new Vector3((float)targetLane, 
                                                transform.position.y, 
                                                transform.position.z);
        //je�li jeste�my na miejscu to zako�cz ruch
        if (transform.position == targetPosition)
        {
            isMoving = false;
            return;
        }
        else
        {
            //jeszcze nie jeste�my na miejscu - przesu� samoch�d w stron� docelow�
            transform.position = Vector3.MoveTowards(transform.position,
                                                        targetPosition,
                                                        Time.deltaTime * laneChangeSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kolizja z: " + other.name);
        if(other.tag == "Coin")
        {
            Destroy(other.gameObject);
            levelManager.AddPoints();
        }
        if (other.tag == "NPCar")
        {
            levelManager.GameOver();
        }
    }
}
