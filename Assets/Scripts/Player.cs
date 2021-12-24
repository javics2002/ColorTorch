using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.2f) {
            characterController.Move(Vector3.forward);
        }
    }
}
