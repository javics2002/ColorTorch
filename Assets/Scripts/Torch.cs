using UnityEngine;

public class Torch : MonoBehaviour
{
    Light torch;

    void Start()
    {
        torch = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            torch.color = Color.red;
        }
    }
}
