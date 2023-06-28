using UnityEngine;

namespace SF
{
    public class Movement : MonoBehaviour
    {
        public Rigidbody rb;
        public Camera cam;

        public float startSpeed;
        public float currentSpeed;
        public float defaultSpeed;
        public float sprintSpeed;
        public float duckSpeed;
        public float maxSpeed;
        public float maxSprintSpeed;
        private float pastSpeed;
        public bool duckcheck;
        public bool sprintcheck;

        public Vector3 movement
        {
            get
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                return new Vector3(horizontal, 0.0f, vertical);
            }
            set{}
        }
        void Start()
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb = GetComponent<Rigidbody>();
            
            currentSpeed = 0.6f;
            defaultSpeed = 0.6f;
            sprintSpeed = 0.7f;
            duckSpeed = 0.5f;
            maxSpeed = 3;
            maxSprintSpeed = 5;
            startSpeed = defaultSpeed;
            duckcheck = false;
            sprintcheck = false;
            
        }


        void FixedUpdate()
        {
            Move();
            

            //if(rb.velocity.magnitude >= maxSpeed) rb.AddForce(-movement * currentSpeed, ForceMode.Impulse);
        }
        private void Update()
        {
            Duck();
            Sprint();
        }

        void Move()
        {   if(Input.GetAxis("W") != 0) rb.AddForce(gameObject.transform.forward.normalized * currentSpeed, ForceMode.Impulse);
            if (Input.GetAxis("S") != 0) rb.AddForce(-gameObject.transform.forward.normalized * currentSpeed, ForceMode.Impulse);
            if (Input.GetAxis("A") != 0) rb.AddForce(-gameObject.transform.right.normalized * currentSpeed, ForceMode.Impulse);
            if (Input.GetAxis("D") != 0) rb.AddForce(gameObject.transform.right.normalized * currentSpeed, ForceMode.Impulse);
            //transform.Translate(moveHorizontal * currentSpeed, 0f, moveVertical * currentSpeed);
        }
        void Duck()
        {
            if (Input.GetAxis("Duck") > 0 && sprintcheck == false)
            {
                Debug.Log("Duck Yes");
                duckcheck = true;
                currentSpeed = duckSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                Debug.Log("Duck No");
                duckcheck = false;
                currentSpeed = defaultSpeed;
            }
        }
        void Sprint()
        {
            if (Input.GetAxis("Sprint") > 0 && duckcheck == false)
            {
                Debug.Log("Sprint Yes");
                sprintcheck = true;
                currentSpeed = sprintSpeed;
                pastSpeed = maxSpeed;
                maxSpeed = maxSprintSpeed;
                
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Debug.Log("Sprint No");
                sprintcheck = false;
                currentSpeed = defaultSpeed;
                maxSpeed = pastSpeed;
            }
        }

    }
}
