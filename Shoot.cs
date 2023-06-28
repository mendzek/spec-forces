using UnityEngine;

namespace SF
{
    public class Shoot : MonoBehaviour
    {
        public GameObject player;
        public float power;
        void Start()
        {
            player = GetComponent<GameObject>();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Hit" + hit.point);
                }

            }
        }
    }
}