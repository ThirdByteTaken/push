using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    const float Start_Speed = 2.0f;

    const int Start_Helpers = 5;

    const int Start_Motivation = 15; // Start amount of seconds before someone leaves

    const int Motivation_Decrease_Rate = 2; // Rate at which motivation decreases after someone leaves

    float playerSpeed;

    int helpers;
    int motivation;

    [SerializeField]
    Transform weight;

    void Start()
    {
        playerSpeed = Start_Speed;
        helpers = Start_Helpers;
        motivation = Start_Motivation;
        Invoke("LoseHelper", motivation);
    }

    [SerializeField]
    CharacterController controller;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            controller.Move(Vector3.forward * (playerSpeed / (Start_Helpers + 1 - helpers)) * Time.deltaTime);
            var weightPos = weight.position;
            weightPos.z = transform.position.z + 1f;
            weight.transform.position = weightPos;
        }
    }

    void LoseHelper()
    {
        helpers--;
        if (helpers == 0) return;
        motivation -= Motivation_Decrease_Rate;
        Invoke("LoseHelper", motivation);
    }
}
