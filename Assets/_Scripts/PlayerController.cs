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

    int nextLimit;

    [SerializeField]
    Transform weight, arms, snowblower;

    [SerializeField]
    List<HelperController> Helpers;

    void Start()
    {
        playerSpeed = Start_Speed;
        helpers = Start_Helpers;
        motivation = Start_Motivation;
        nextLimit = motivation;
    }

    [SerializeField]
    CharacterController controller;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Helpers.Count == 0) return;
            controller.Move(Vector3.forward * (playerSpeed / (Start_Helpers + 1 - helpers)) * Time.deltaTime);

            var weightPos = weight.position;
            weightPos.z = transform.position.z + 1f;
            weight.transform.position = weightPos;

            var armPos = arms.position;
            armPos.z = transform.position.z + 0.622f;
            arms.transform.position = armPos;

            foreach (var helper in Helpers)
            {
                var hPos = helper.transform.position;
                hPos.z = transform.position.z - 0.6f;
                helper.transform.position = hPos;
                helper.MoveForward();
            }

            if (Helpers[0].transform.position.z > nextLimit)
            {
                Helpers[0].GiveUp();
                helpers--;
                motivation -= Motivation_Decrease_Rate;
                nextLimit += motivation;
                Helpers.RemoveAt(0);
            }
        }
        else
        {
            foreach (var helper in Helpers)
            {
                helper.StandStill();
            }
        }
    }
}
