using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D _rigidbody;

    public float flapForce = 4f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    public float deathCooldown = 0f;

    public bool isFlap = false;

    public bool godMode = false;

    GameManager gameManager;

    // class 에 적으면 다른 함수에 적용된게 아니라 , 다른함수에서 사용할수있도록 좌판에 깔아둔 것이다. 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Animator 를 찾을 수 없습니다.");

        if (_rigidbody == null)
            Debug.LogError("Rigidbody 를 찾을 수 없습니다.");


    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                // 게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead == true)
        {
            return;
        }

        Vector3 velocity = _rigidbody.velocity; // 선언한거지 , 가져온게 아니다.
        velocity.x = forwardSpeed;

        if (isFlap == true)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        // 여기서 velocity 넣어주기 

        _rigidbody.velocity = velocity;


        // 점프만 아니라, 각도도 꺾였으면 좋겠다
        //Mathf.Clamp 는 
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -60, 60); //계산만 한 것 
        transform.rotation = Quaternion.Euler(0, 0, angle); // 명령 하는것 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode == true)
        {
            return;
        }
        if (isDead == true)
        {
            return;
        }

        isDead = true;
        deathCooldown = 1f; // 죽고나면 1초 있다가 게임을 재시작하게

        animator.SetInteger("isDie", 1);
        gameManager.gameover();



    }
}