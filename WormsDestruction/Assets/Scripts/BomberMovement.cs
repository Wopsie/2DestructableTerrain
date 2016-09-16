using UnityEngine;
using System.Collections;

public class BomberMovement : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D rb;

    private bool facingRight;

    void Start()
    {
        facingRight = true;
    }

	void Update()
    {
        if (facingRight)
            rb.AddForce(Vector2.right * 3);
        else
            rb.AddForce(Vector2.left * 3);

        if (!facingRight)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
            transform.localScale = new Vector3(1, 1, 0);


        if(Input.GetKey(KeyCode.LeftArrow))
        {
            facingRight = false;
        }else if(Input.GetKey(KeyCode.RightArrow))
        {
            facingRight = true;
        }
    }
}
