using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    const float playerSpeed = 2.0f;

    [SerializeField]
    CharacterController controller;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            controller.Move(transform.forward * playerSpeed * Time.deltaTime);
        }
    }
}
