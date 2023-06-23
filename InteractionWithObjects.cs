using SF;
using System.Threading;
using UnityEngine;
namespace SF
{
    public class InteractionWithObjects : MonoBehaviour
    {
        public GameObject Player;
        public GameObject InteractionObjectSide;
        public CameraMovements CamMove;
        public Camera Cam;
        public Movement movement;

        public float maxDistance;
        public float distance;
        public bool canInteract;
        //public bool canSee;
        void Start()
        {
            maxDistance = 2;
            canInteract = false;
            //canSee = false;
        }

        void Update()
        {
            InteractionObjectSide.transform.rotation = Quaternion.Euler(-CamMove.mouseY * CamMove.sensivity, CamMove.mouseX * CamMove.sensivity, 0f);
            if (movement.duckcheck == false) InteractionObjectSide.transform.position = Cam.transform.position;
            else InteractionObjectSide.transform.position = Vector3.Lerp(Player.transform.position, Player.transform.position - new Vector3(0, 0.208f, 0), 1);

            if (Input.GetKeyDown(KeyCode.E) && canInteract == true /*&& canSee == true*/)
            {
                Debug.Log("took ammo");
            }
        }
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Trigger radius")
            {
                canInteract = true;
                Debug.Log("Entered");
            }

        }
        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "Trigger radius")
            {
                canInteract = false;
                Debug.Log("Exit");
            }

        }
    }
}
