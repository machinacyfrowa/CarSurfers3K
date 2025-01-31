using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadSegmentPrefab;
    private GameObject lastSpawnedSegment;
    // Start is called before the first frame update
    void Start()
    {
        //spawnujemy recznie pierwszy segment drogi
        lastSpawnedSegment = Instantiate(roadSegmentPrefab, transform.position, Quaternion.identity);
        //zapisujemy sobie referencje do pierwszego segmentu drogi ¿eby go przywróciæ póŸniej
        GameObject firstSpawnedSegment = lastSpawnedSegment;
        //odpalamy rozgrzewkê ¿eby mieæ kilka segmentów drogi na starcie
        WarmUp();
        //przywracamy pierwszy segment drogi
        lastSpawnedSegment = firstSpawnedSegment;
    }

    // Update is called once per frame
    void Update()
    {
        //sprawdz odleg³oœc od ostatniego segmentu drogi
        float distance = Vector3.Distance(lastSpawnedSegment.transform.position, transform.position);
        if (distance > 6)
        {
            
            Vector3 newSpawnPosition = lastSpawnedSegment.transform.position + new Vector3(0, 0, 6f);
            lastSpawnedSegment = Instantiate(roadSegmentPrefab, newSpawnPosition, Quaternion.identity);
        }
    }
    void WarmUp()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 newSpawnPosition = lastSpawnedSegment.transform.position + new Vector3(0, 0, -6f);
            lastSpawnedSegment = Instantiate(roadSegmentPrefab, newSpawnPosition, Quaternion.identity);
            lastSpawnedSegment.name = "WarmupRoadSegment" + i;
        }
    }
}