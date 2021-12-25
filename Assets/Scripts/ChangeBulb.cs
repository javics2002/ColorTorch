using UnityEngine;
using UnityEngine.UI;

public class ChangeBulb : MonoBehaviour
{
    Color bulb;
    Flashlight flashlight;

    void Start()
    {
        bulb = GetComponent<Image>().color;
        flashlight = GetComponentInParent<Flashlight>();
    }

    public void SetColor()
    {
        flashlight.SetColor(bulb);
    }
}
