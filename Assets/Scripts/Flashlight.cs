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
        UpdateTriggers();
    }

    private void UpdateTriggers()
    {
        for (int color = 0; color < rgb.Length; color++)
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
        SetTrigger(other.gameObject.GetComponent<ColorReactor>());
    }

    private void OnTriggerStay(Collider other)
    {
        if(updateTriggers)
        {
            SetTrigger(other.gameObject.GetComponent<ColorReactor>());
        }
    }

    private void SetTrigger(ColorReactor cr) 
    { 
        //Decides whether the object becomes a trigger of not depending on its colors
        if (cr != null)
        {
            //The object will become trigger if it's not being enlightned by any of its colors.
            Color objectColor = cr.GetColor();
            cr.GetComponent<Collider>().isTrigger = !(bulb.r == 1 && objectColor.r > 0 ||
            bulb.g == 1 && objectColor.g > 0 ||
            bulb.b == 1 && objectColor.b > 0);
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
