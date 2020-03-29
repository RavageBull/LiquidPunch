using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JellYfish
{
    public class JellyFishWandering : MonoBehaviour
    {
        public Rigidbody mainBoneRigidBody;

        public float directionChangeFrequency;
        public float directionChangeMultiplier;
        public float seedX,seedY,seedZ;
        // Start is called before the first frame update
        
        // Update is called once per frame
        private void Start()
        {
            float rand = Random.Range(-1f, 1f);
            seedX += rand;
            seedY += rand;
            seedZ += rand;
        }

        void Update()
        {

            Wander();
        }



        void Wander()
        {
            
            float x = Mathf.PerlinNoise(Time.time * directionChangeFrequency,seedX) -0.5f;
            float y = Mathf.PerlinNoise(Time.time * directionChangeFrequency,seedY)-0.5f;
            float z = Mathf.PerlinNoise(Time.time * directionChangeFrequency,seedZ)-0.5f;
            
            mainBoneRigidBody.AddTorque(transform.TransformDirection(new Vector3(x,y,z).normalized * directionChangeMultiplier));
        }
    }
}
