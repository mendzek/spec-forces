using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Sphere;
    public float Power;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit"+hit.point);
            }

        }
    }
}