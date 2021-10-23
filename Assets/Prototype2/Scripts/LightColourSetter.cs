using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class LightColourSetter : MonoBehaviour, DayNightInterface
{
    public Gradient gradient;
    public Light[] lights;
    
    
    public void GetComponent()
    {
        lights = GetComponentInChildren<Light[]>();
    }

    public void SetParameter(float _time)
    {
        foreach (var light in lights)
        {
            light.color = gradient.Evaluate(_time);
        }
    }

}
