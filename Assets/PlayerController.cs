using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//lane przechowuje wspó³rzêdne x dla konkretnych pasów drogowych
enum Lane
{
    LEFT = -2,
    CENTER = 0,
    RIGHT = 2
}

public class PlayerController : MonoBehaviour
{
    //docelowy pas na którym jesteœmy albo na który chcemy siê przemieœciæ
    Lane targetLane;
    //zmienna, flaga wskazuj¹ca czy aktualnie zmieniamy pas
    bool isMoving;
    //prêdkoœæ zmiany pasa
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
        //zapisujemy ruch lewo prawo, a ignorujemy ruch góra dó³
        //getaxisraw dzia³a binarnie (-1, 0, 1) - bez u³amków
        if (!isMoving)
            GetInput();
        else
            Move(); //je¿eli flaga isMoving jest true to wykonaj funkcjê Move

        //Debug.Log("Docelowy pas:" + targetLane);

    }
    void GetInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        //je¿eli nie jest nic wciœniête to zakoñcz funkcjê
        if (input == Vector2.zero)
            return;
        //obecna pozycja samochodu zaokr¹glona do liczby ca³kowitej
        int currentLane = (int)transform.position.x;
        //dodaj do obecnej pozycji samochodu wartoœæ wektora wejœciowego
        //mo¿liwe sytuacje - dodaj -2 przesunie w lewo, dodaj 2 przesunie w prawo
        currentLane += (int)input.x * 2;
        //ograniczenie ruchu do pasów drogowych
        currentLane = Mathf.Clamp(currentLane, (int)Lane.LEFT, (int)Lane.RIGHT);
        //ustaw docelowy pas
        targetLane = (Lane)currentLane;
        //ustaw flagê ruchu
        isMoving = true;
    }
    void Move()
    {
        //docelowa pozycja to obecna pozycja ze zmienion¹ osi¹ x na nowy pas
        Vector3 targetPosition = new Vector3((float)targetLane, 
                                                transform.position.y, 
                                                transform.position.z);
        //jeœli jesteœmy na miejscu to zakoñcz ruch
        if (transform.position == targetPosition)
        {
            isMoving = false;
            return;
        }
        else
        {
            //jeszcze nie jesteœmy na miejscu - przesuñ samochód w stronê docelow¹
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
