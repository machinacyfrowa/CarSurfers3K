using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPropsSpawner : MonoBehaviour
{
    List<GameObject> props = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            props.Add(transform.GetChild(i).gameObject);
            if(Random.Range(0, 2) == 0)
            {
                props[i].SetActive(false);
            }
            else
            {
                props[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
