using UnityEngine;

public class ColorReactor : MonoBehaviour
{
    [SerializeField, Tooltip("Color of the object. It will react to lights that include this color.")]
    Color color;
    new Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", color);
    }

    public Color GetColor() { return color; }
}
