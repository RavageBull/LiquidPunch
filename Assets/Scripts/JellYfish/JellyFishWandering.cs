using UnityEngine;
using Random = UnityEngine.Random;



    namespace Jellyfish
    {
        public class JellyFishWandering : MonoBehaviour
        {
            public Rigidbody mainBoneRigidBody;

            public float directionChangeFrequency;
            public Vector3 directionChangeMultiplier;
            public float seedX;
            public float seedY;
            public  float seedZ;
            // Start is called before the first frame update
        
            // Update is called once per frame
            private void Start()
            {
                float rand = Random.Range(-1f, 1f);
                seedX += rand;
                seedY += rand;
                seedZ += rand;
            }

            void FixedUpdate()
            {

                Wander();

            }



            void Wander()
            {
                float t = Time.time;
            
                float x = (Mathf.PerlinNoise(t * directionChangeFrequency,seedX) -0.5f )* directionChangeMultiplier.x;
                float y = (Mathf.PerlinNoise(t * directionChangeFrequency,seedY) -0.5f )* directionChangeMultiplier.y;
                float z = (Mathf.PerlinNoise(t * directionChangeFrequency,seedZ) -0.5f) * directionChangeMultiplier.z;
            
                mainBoneRigidBody.AddTorque(transform.TransformDirection(new Vector3(x,y,z)));
            }
        
        
        
        
        }
    }

