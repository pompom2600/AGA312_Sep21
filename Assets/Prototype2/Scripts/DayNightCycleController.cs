using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DayNightInterface
{
    void GetComponent();

    void SetParameter(float _time);
}
[ExecuteInEditMode]
public class DayNightCycleController : MonoBehaviour
{
    [Range(0, 1)]
    public float time;
    public DayNightInterface[] setters;
    public bool day;


    private void OnEnable()
    {
        time = 0;
        day = true;
        GetSetters();
    }

    private void GetSetters()
    {
        setters = GetComponentInChildren<DayNightInterface[]>();
        foreach (var setter in setters)
        {
            setter.GetComponent();
        }
    }

    private void Update()
    {
        if (setters.Length > 0)
        {
            foreach (var setter in setters)
            {
                setter.SetParameter(time);
            }
        }
    }

}
