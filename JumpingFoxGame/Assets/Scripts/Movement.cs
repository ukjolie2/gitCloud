using System.Collections;
using UnityEngine;
using Prime31;

public class Movement : MonoBehaviour {

    public float walkSpeed = 20;
    public float gravity = -10;
    public float jumpHeight = 1000;
    public GameObject gameOver;
    public GameObject gameCamera;

    private CharacterController2D _body;
    private AnimationController2D _animator;


    // Use this for initialization
    void Start()
    {
        _body = gameObject.GetComponent<CharacterController2D>();
        _animator = gameObject.GetComponent<AnimationController2D>();
        gameCamera.GetComponent<CameraFollow2D>().startCameraFollow(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = _body.velocity;
        if (Input.GetAxis("Horizontal") < 0)
        {
            velocity.x = -walkSpeed;
            if (_body.isGrounded != true)
            {
                if (velocity.y > 0)
                {
                    _animator.setAnimation("JumpingUp");
                }

                else
                {
                    _animator.setAnimation("JumpingDown");
                }
            }
            else
            {
                _animator.setAnimation("idle");
            }
            _animator.setFacing("Left");
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            velocity.x = walkSpeed;
            if (_body.isGrounded != true)
            {
                if (velocity.y > 0)
                {
                    _animator.setAnimation("JumpingUp");
                }

                else
                {
                    _animator.setAnimation("JumpingDown");
                }
            }
            else
            {
                _animator.setAnimation("idle");
            }
            _animator.setFacing("Right");
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
        if (collision.tag == "Death")
        {
            print("got here!");
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        gameCamera.GetComponent<CameraFollow2D>().stopCameraFollow();
        gameOver.SetActive(true);
    }
}
