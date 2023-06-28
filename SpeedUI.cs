using System;
using TMPro;
using UnityEngine;
namespace SF
{
    public class SpeedUI : MonoBehaviour
    {
        public TextMeshProUGUI tmp;
        public Rigidbody rb;
        public Movement movement;

        void Start()
        {

        }


        void Update()
        {
            //tmp.text = "Speed: " + Convert.ToString(Convert.ToInt32(rb.velocity.magnitude));
            tmp.text = "Speed: " + Convert.ToString(Convert.ToInt32(movement.rb.velocity.magnitude));
        }
    }
}