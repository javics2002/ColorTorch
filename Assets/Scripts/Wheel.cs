using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField, Tooltip("Color wheel gameObject")]
    GameObject wheel;

    //https://www.youtube.com/watch?v=MRdQyrpflB4
    void Update()
    {
        if(Input.GetButtonDown("Wheel"))
            wheel.SetActive(true);

        else if(Input.GetButtonUp("Wheel"))
            wheel.SetActive(false);


    }
}
