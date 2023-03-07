using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody myRB;
    float dieTimer = 1;
    public static float flowRate = 0.002656f, grateFlowRate = 0.97445f, evaporationRate = 0.0000373f;

    // Start is called before the first frame update
    void Start()
    {
        myRB.velocity = Random.onUnitSphere * 3;
        UIController.numDrops++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dieTimer < 0)
        {
            UIController.numDrops--;
            Destroy(gameObject);
            return;
        }
        if (transform.position.z > 10 && transform.position.x > 1.5f)
        {
            DrainRate(grateFlowRate * UIController.timeSkip);
        }
        if (transform.position.y < 1.2f)
        {
            DrainRate(flowRate * UIController.timeSkip);
        }
        DrainRate(evaporationRate * UIController.timeSkip);
    }

    void DrainRate(float rate)
    {
        dieTimer -= Time.deltaTime * rate;
        float newScale = Mathf.Pow(0.75f * dieTimer / Mathf.PI, 0.333f) * 0.529f;
        if (float.IsNaN(newScale))
            newScale = 0;
        transform.localScale = newScale * Vector3.one;
    }
}
