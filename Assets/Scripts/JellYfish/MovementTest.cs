using UnityEngine;

namespace JellYfish
{
    public class MovementTest : MonoBehaviour
    {
        public Rigidbody mainBoneRigidBody;
        
        public KeyCode jump,forward,backward,left,right;
        private Vector3 movementVelocity;
        private Vector3 rotateVelocity;
        public float movementSpeed;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            movementVelocity = Vector3.zero;
            rotateVelocity = Vector3.zero;
            if (Input.GetKey(forward))
            {
                rotateVelocity += mainBoneRigidBody.transform.forward;
            }
            if (Input.GetKey(backward))
            {
                rotateVelocity += -mainBoneRigidBody.transform.forward;
            }
            if (Input.GetKey(right))
            {
                rotateVelocity += mainBoneRigidBody.transform.right;
            }
            if (Input.GetKey(left))
            {
                rotateVelocity += -mainBoneRigidBody.transform.right;
            }
            if (Input.GetKey(jump))
            {
                movementVelocity += -mainBoneRigidBody.transform.up;
            }
            
            mainBoneRigidBody.AddTorque(rotateVelocity.normalized);
            mainBoneRigidBody.AddForce(movementVelocity * movementSpeed);
            
  

            
        }
    }
}
