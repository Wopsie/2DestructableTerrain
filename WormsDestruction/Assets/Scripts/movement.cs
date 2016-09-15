using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour {

    private Rigidbody2D rb;


    [Range(0,5)]
    [SerializeField]
    private float moveSpeed;

    [Range(0,100)]
    [SerializeField] private float maxMovSpeed;
    private float currMovSpeed;

    [Range(0,15)]
    [SerializeField] private float strafeSpeed;

    [Range(0,20)]
    [SerializeField] private float maxStrafe;
    private float currStrafe;

    private float stopMargin;

    void Start()
    {
        stopMargin = maxStrafe / 15;

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(maxMovSpeed > currMovSpeed)
        {
            rb.AddRelativeForce(new Vector2(0, moveSpeed) * Time.time);  
        }
    }

    void Update()
    {
        currMovSpeed = rb.velocity.y;
        currStrafe = rb.velocity.x;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //this.transform.Rotate(new Vector3(0, 0, 5));


            rb.AddForce(new Vector2(-strafeSpeed,0));
        }
        else if (!Input.GetKey(KeyCode.LeftArrow))
        {
            DeAccelerateVertical(strafeSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //this.transform.Rotate(new Vector3(0, 0, -5));

            rb.AddForce(new Vector2(strafeSpeed, 0));
        }
        else if(!Input.GetKey(KeyCode.RightArrow))
        {
            DeAccelerateVertical(strafeSpeed);
        }
    }


    void DeAccelerateVertical(float force)
    {
        if (currStrafe > stopMargin)
        {
            currStrafe -= force * Time.deltaTime;
        }
        else if (currStrafe < -stopMargin)
        {
            currStrafe += force * Time.deltaTime;
        }
        if (currStrafe >= -stopMargin && currStrafe <= stopMargin)
        {
            currStrafe = 0;
        }
    }

}
