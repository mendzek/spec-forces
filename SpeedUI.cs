using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
namespace SF
{
    public class SpeedUI : MonoBehaviour
    {
        public TextMeshProUGUI tmp;
        public Rigidbody rb;

        void Start()
        {

        }


        void Update()
        {
            tmp.text = "Speed: " + Convert.ToString(Convert.ToInt32(rb.velocity.magnitude));
        }
    }
}