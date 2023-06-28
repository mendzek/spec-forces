using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SF
{
    public class CameraMovements : MonoBehaviour
    {
        public Camera Cam;
        public GameObject Player;
        public Movement movement;
        public Vector3 DuckPosition;
        
        public float mouseX;
        public float mouseY;
        public float sensivity;
        public float minX;
        public float maxX;
        public float maxDuck;
        public float duckDownSpeed;
        void Start()
        {
            Cam = GetComponent<Camera>();
            Cam.transform.position = Player.transform.position;
            sensivity = 1;
            minX = -70f;
            maxX = 70f;
            maxDuck = 0.25f;
            duckDownSpeed = Time.time+1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            DuckPosition= transform.position;
            DuckPosition.y -= 0.208f;
            if (movement.duckcheck == false) Cam.transform.position = Player.transform.position;
            else Cam.transform.position = Vector3.Lerp(Player.transform.position,Player.transform.position - new Vector3(0, 0.208f, 0),1);
            //else Cam.transform.position = Vector3.Lerp(Cam.transform.position, DuckPosition,0.05f);
            MouseMovement();
        }
        public void MouseMovement()
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY += Math.Clamp(Input.GetAxis("Mouse Y"),-70, 70);//x=-70f
            if(mouseY >= 70) { mouseY = 70; }
            if (mouseY <= -70) { mouseY = -70; }
            Cam.transform.rotation = Quaternion.Euler(-mouseY * sensivity, mouseX * sensivity, 0f);
            Player.transform.rotation = Quaternion.Euler(0f, mouseX, 0f);
            //Player.transform.rotation = Cam.transform.rotation;
        }
    }
}
