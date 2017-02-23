using System.Collections;
using UnityEngine;
using Prime31;

public class Movement : MonoBehaviour
{

    public float walkSpeed = 20;
    public float gravity = -10;
    public float jumpHeight = 1000;
    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject gameCamera;
    public bool isStopped = false;

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

        if (_body.isGrounded)
        {
            if (Input.GetKey(KeyCode.F))
                _animator.setAnimation("Dancing");
            else
                _animator.setAnimation("Idle");
        }
        else if (_body.velocity.y > 1)
            _animator.setAnimation("JumpingUp");
        else if (_body.velocity.y < 1)
            _animator.setAnimation("JumpingDown");

        if (Input.GetAxis("Horizontal") < 0)
        {
            _animator.setFacing("Left");
            _body.velocity.x = -walkSpeed;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            _animator.setFacing("Right");
            _body.velocity.x = walkSpeed;
        }
        else
            _body.velocity.x = 0;

        if (Input.GetAxis("Jump") > 0 && _body.isGrounded)
        {
            _body.velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
        }
        _body.velocity.x *= 0.85f;
        _body.velocity.y += gravity * Time.deltaTime;
        _body.move(_body.velocity * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Death")
        {
            PlayerDeath();
        }

        if (collision.tag == "Win")
            PlayerWin();
    }

    private void PlayerWin()
    {
        gameCamera.GetComponent<CameraFollow2D>().stopCameraFollow();
        gameWin.SetActive(true);
        isStopped = true;
    }

    private void PlayerDeath()
    {
        gameCamera.GetComponent<CameraFollow2D>().stopCameraFollow();
        isStopped = true;
        gameOver.SetActive(true);
    }
}
