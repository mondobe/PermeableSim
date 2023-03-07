using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    float spawnTimer;
    const float MAX_TIMER = 1f;
    public GameObject water;
    public static float rainRate = 0.00068f;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = MAX_TIMER;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime * rainRate * UIController.timeSkip;
        if (spawnTimer < 0 && rainRate > 0)
        {
            spawnTimer = MAX_TIMER;
            float newX = Random.Range(-19.4f, 3.55f);
            float newZ = Random.Range(-11.13f, 11.84f);
            while(newX < -4.21 && newZ < 4.24)
            {
                newX = Random.Range(-19.4f, 3.55f);
                newZ = Random.Range(-11.13f, 11.84f);
            }
            Vector3 newPos = new Vector3(newX, 4.8f, newZ);
            GameObject w = Instantiate(water, newPos, Quaternion.identity);
        }
    }
}
