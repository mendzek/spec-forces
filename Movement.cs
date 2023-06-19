using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SF
{
    public class Movement : MonoBehaviour
    {
        public Rigidbody rb;
        public Camera cam;

        public float speed;
        public bool duckcheck;
        public bool sprintcheck;
        void Start()
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            speed = 0.01f;
            duckcheck = false;
            sprintcheck = false;
        }


        void Update()
        {
            Move();
            Duck();
            Sprint();
        }
        void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
            //rb.AddForce(movement * speed, ForceMode.Impulse);
            transform.Translate(moveHorizontal*speed,0f, moveVertical*speed);
        }
        void Duck()
        {
            if(Input.GetKeyDown(KeyCode.LeftControl) && sprintcheck == false) 
            {
                Debug.Log("Duck Yes");
                duckcheck = true;
                speed = 0.005f;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                Debug.Log("Duck No");
                duckcheck = false;
                speed = 0.01f;
            }
        }
        void Sprint()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && duckcheck == false)
            {
                Debug.Log("Sprint Yes");
                sprintcheck = true;
                speed = 0.05f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Debug.Log("Sprint No");
                sprintcheck = false;
                speed = 0.01f;
            }
        }
    }
}
