using System.Collections;
using UnityEngine;
using Prime31;

public class Movement : MonoBehaviour {

    public float walkSpeed = 5;
    public float gravity = -35;
    public float jumpHeight = 4;
    private CharacterController2D _body;
	// Use this for initialization
	void Start () {
        _body = gameObject.GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velocity = _body.velocity;
        if(Input.GetAxis("Horizontal") < 0)
        {
            velocity.x = -walkSpeed;
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            velocity.x = walkSpeed;
        }
        else
        {
            velocity.x = 0;
        }
        if (Input.GetAxis("Jump") > 0 && _body.isGrounded)
        {
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
        }
        velocity.x *= 0.85f;
        velocity.y += gravity * Time.deltaTime;
        _body.move(velocity * Time.deltaTime);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Land")
        {
            
        }
    }
}
