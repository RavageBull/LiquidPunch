using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoverScript : MonoBehaviour
{

    public KeyCode forward;

    public KeyCode backward;

    public KeyCode left;

    public KeyCode right;

    public float movementSpeed;

    private Vector3 MovementVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementVelocity = Vector3.zero;
        if (Input.GetKey(forward))
        {
            MovementVelocity += Vector3.forward;
        }
        if (Input.GetKey(backward))
        {
            MovementVelocity += -Vector3.forward;
        }
        if (Input.GetKey(right))
        {
            MovementVelocity += Vector3.right;
        }
        if (Input.GetKey(left))
        {
            MovementVelocity += -Vector3.right;
        }

        transform.position += MovementVelocity.normalized * movementSpeed;
        

    }
}
