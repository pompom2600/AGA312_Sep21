using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    TiltControl tiltControl;

    private void Start()
    {
        tiltControl = FindObjectOfType<TiltControl>();
    }


   /* void Update()
    {
        if (transform.position.y < -10)
        {
            //Debug.Log(transform.position.y);
            tiltControl.SpawnEgg();
            Destroy(gameObject);
        }

    }*/
}
