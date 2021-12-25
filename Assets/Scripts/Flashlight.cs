using System.Collections;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [Tooltip("Color of the light")]
    Color bulb;

    new Light light;
    bool updateTriggers = false;
    string[] rgb = { "Red", "Green", "Blue" };

    void Start()
    {
        light = GetComponentInChildren<Light>();
        bulb = light.color;
    }

    private void Update()
    {
        for(int color = 0; color < rgb.Length; color++)
        {
            if (Input.GetButtonDown(rgb[color])) //y puedo hacer eso
            {
                bulb[color] = bulb[color] == 0 ? 1 : 0;
                SetColor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ColorReactor cr = other.gameObject.GetComponent<ColorReactor>();
        if (cr != null)
        {
            Color objectColor = cr.GetColor();
            cr.GetComponent<Collider>().isTrigger = bulb.r == 0 && objectColor.r > 0 ||
            bulb.g == 0 && objectColor.g > 0 ||
            bulb.b == 0 && objectColor.b > 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(updateTriggers)
        {
            ColorReactor cr = other.gameObject.GetComponent<ColorReactor>();
            if (cr != null)
            {
                Color objectColor = cr.GetColor();
                cr.GetComponent<Collider>().isTrigger = bulb.r == 0 && objectColor.r > 0 ||
                bulb.g == 0 && objectColor.g > 0 ||
                bulb.b == 0 && objectColor.b > 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ColorReactor cr = other.gameObject.GetComponent<ColorReactor>();
        if (cr != null)
        {
            cr.GetComponent<Collider>().isTrigger = false;
        }
    }

    public void SetColor(Color newColor)
    {
        light.color = bulb = newColor;

        //Actualizamos los triggers de los objetos en base al nuevo color
        updateTriggers = true;
        StartCoroutine(StopUdatingTriggers());
    }

    public void SetColor()
    {
        light.color = bulb;

        //Actualizamos los triggers de los objetos en base al nuevo color
        updateTriggers = true;
        StartCoroutine(StopUdatingTriggers());
    }

    IEnumerator StopUdatingTriggers()
    {
        //Cuando se termine con todos los OnTriggerStay que actualizan los triggers, se paran de actualizar
        yield return new WaitForFixedUpdate();
        updateTriggers = false;
    }
}
