using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    Light2D globalLight;
    bool posOrNeg;
    float lightamount = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        globalLight = GetComponent<Light2D>();
        globalLight.intensity = lightamount;
        posOrNeg = false;
        StartCoroutine(dayAndNightCycleTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator dayAndNightCycleTimer()
    {
        
        if (posOrNeg)
        {
            lightamount += 0.1f;
            if (lightamount > 0.9f)
            {
                posOrNeg = false;
            }
            globalLight.intensity = lightamount;
        }
        else
        {
            lightamount -= 0.1f;
            
            if (lightamount < 0.1f)
            {
                posOrNeg = true;
            }
            globalLight.intensity = lightamount;

        }
        yield return new WaitForSeconds(10);
        StartCoroutine(dayAndNightCycleTimer());
    }
}
