using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public FreeFlyCamera ffc;
    public TextMeshProUGUI readouts;
    public static float timeSkip;
    public static int numDrops;

    // Start is called before the first frame update
    void Start()
    {
        numDrops = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ffc.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if(Input.GetKeyDown(KeyCode.F11)) 
        {
            if (Screen.fullScreenMode == FullScreenMode.Windowed)
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            else
                Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        readouts.text = "Rain: ~" + (WaterSpawner.rainRate * 3600).ToString("0.000") 
            + " L/h\nPavement: ~" + (Water.flowRate * 3600 * numDrops).ToString("0.000")
            + " L/h\nGrate: ~" + (Water.grateFlowRate * 360 * numDrops).ToString("0.000")
            + " L/h\nEvaporation ~" + (Water.evaporationRate * 3600 * numDrops).ToString("0.000") + " L/h";
    }

    public void EnableCamMovement()
    {
        ffc.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetRain(float rate)
    {
        WaterSpawner.rainRate = rate;
    }

    public void SetPermeable(float rate)
    {
        Water.flowRate = rate;
    }

    public void SetGrate(float rate)
    {
        Water.grateFlowRate = rate;
    }

    public void SetEvaporation(float rate)
    {
        Water.evaporationRate = rate;
    }

    public void SetTimeSkip(float skip)
    {
        timeSkip = skip;
    }
}
