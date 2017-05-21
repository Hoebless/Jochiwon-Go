using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    //walk, jump
    public float maxSpeed;
    public float speed;
    public float jumpPower;

    //ground
    public bool grounded;

    //climb
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    Rigidbody2D rb2d;
    Animator anim;

	void Start () 
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Player climbing
        gravityStore = rb2d.gravityScale;
	}
	
	void Update () 
    {
        //애니메이션 매개변수값 설정
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        //애니메이션 스피드
        anim.speed = speed/35;

        //플레이어 왼쪽 오른쪽 스프라이트
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                anim.SetTrigger("Jump");
            }
        }

        //사다리 on
        if (onLadder)
        {
            rb2d.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            rb2d.velocity = new Vector2(rb2d.velocity.x, climbVelocity);

            if(Mathf.Abs(climbVelocity) > 0)
            {
                anim.SetLayerWeight(2, 1);
            }
            anim.speed = Mathf.Abs(climbVelocity); //사다리랑 trigger되면 anim.speed 0됨...
        }

        //사다리 off
        if (!onLadder)
        {
            rb2d.gravityScale = gravityStore;

            anim.SetLayerWeight(2, 0);
            anim.speed = 1;
        }
	}

    void FixedUpdate()
    {
        Vector3 easyvelocity = rb2d.velocity;
        easyvelocity.y = rb2d.velocity.y;
        easyvelocity.z = 0.0f;
        easyvelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //마찰력 주기
        if (grounded)
        {
            rb2d.velocity = easyvelocity;
        }

        //플레이어 움직이기
        rb2d.AddForce(Vector2.right * speed * h);

        //플레이어 최고속도 주기
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        HandleLayers();
    }

    void HandleLayers()
    {
        if (!grounded)
        {
            anim.SetLayerWeight(1, 1);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }

    public void Damage()
    {
        //씬은 세이브포인트 구현되면 그걸로 바꾸기...
        SceneManager.LoadScene("Jochiwon");
    }
}
