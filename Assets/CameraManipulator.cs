using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManipulator : MonoBehaviour
{
    CharacterController cc;


    public float max_speed = 20.0f;
    public float acceleration = 2.0f;
    public float rotationSensitivity = 3.0f;

    private float speed = 0f;
    private float curVertialSpeed = 0f;
    public float gravity = 9.8f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Alpha1))
        {
            cc.transform.position = new Vector3(48, 1, 0);
        }
        else if (Input.GetKey(KeyCode.Alpha2)) {
            cc.transform.position = new Vector3(-6, 1, 0);
        }
        else {
            //rotation updates
            {
                yaw += Input.GetAxis("Mouse X") * rotationSensitivity;
                pitch -= Input.GetAxis("Mouse Y") * rotationSensitivity;

                transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -89f, 89f), yaw, 0); ;
            }

            //movement updates
            {
                bool moving = false;
                Vector3 movement = new Vector3();
                if (Input.GetKey(KeyCode.A))
                {
                    movement.x -= 1;
                    moving = true;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    movement.x += 1;
                    moving = true;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    movement.z -= 1;
                    moving = true;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    movement.z += 1;
                    moving = true;
                }

                if (moving)
                {
                    speed = Mathf.Min(speed + (acceleration * Time.deltaTime), max_speed);
                }
                else {
                    speed = 0;
                }

                movement = movement * (speed * Time.deltaTime);
                movement = Quaternion.Euler(0, yaw, 0) * movement;
                cc.Move(movement);
            }

            //gravity
            {
                curVertialSpeed = curVertialSpeed - 10.0f * Time.deltaTime;
                Vector3 fall = new Vector3(0, curVertialSpeed * Time.deltaTime, 0);
                cc.Move(fall);
            }
        }

    }
}
