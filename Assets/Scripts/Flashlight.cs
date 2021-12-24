using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Tooltip("Color of the light")]
    Color bulb;

    private void OnTriggerEnter(Collider other)
    {
        ColorReactor cr = other.gameObject.GetComponent<ColorReactor>();
        if (cr != null)
        {
            Color objectColor = cr.GetColor();
            cr.GetComponent<Collider>().isTrigger = bulb.r == 0 && objectColor.r == 0 ||
            bulb.g == 0 && objectColor.g == 0 ||
            bulb.b == 0 && objectColor.b == 0;

            Debug.Log(cr.GetComponent<Collider>().isTrigger);
        }
        Debug.Log(cr != null);
    }

    private void OnTriggerExit(Collider other)
    {
        ColorReactor cr = other.gameObject.GetComponent<ColorReactor>();
        if (cr != null)
        {
            cr.GetComponent<Collider>().isTrigger = false;
        }
    }
}
