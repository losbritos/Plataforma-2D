using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 20;
    public float force_air = 100;
    public int jump_max = 2;
    int jump;
    GroundDetector_Raycast ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundDetector_Raycast>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ground.grounded)
        {
            jump = jump_max;
        }

        if (Input.GetButtonDown("Jump") && jump > 0 )
        {
            rb.AddForce(new Vector2(0,force));
            jump--;

            if (ground.grounded)
            {
                rb.AddForce(new Vector2(0, force));
            }
            else
            {
                rb.AddForce(new Vector2(0,force_air));
            }
        }
    }
}
