using UnityEngine;

namespace Tornado
{
    public class TestMoverScript : MonoBehaviour
    {

        public KeyCode forward;

        public KeyCode backward;

        public KeyCode left;

        public KeyCode right;

        public float movementSpeed;

        private Vector3 movementVelocity;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            movementVelocity = Vector3.zero;
            if (Input.GetKey(forward))
            {
                movementVelocity += Vector3.forward;
            }
            if (Input.GetKey(backward))
            {
                movementVelocity += -Vector3.forward;
            }
            if (Input.GetKey(right))
            {
                movementVelocity += Vector3.right;
            }
            if (Input.GetKey(left))
            {
                movementVelocity += -Vector3.right;
            }

            transform.position += movementVelocity.normalized * movementSpeed;
        

        }
    }
}
