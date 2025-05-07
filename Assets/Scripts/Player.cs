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

    // class �� ������ �ٸ� �Լ��� ����Ȱ� �ƴ϶� , �ٸ��Լ����� ����Ҽ��ֵ��� ���ǿ� ��Ƶ� ���̴�. 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Animator �� ã�� �� �����ϴ�.");

        if (_rigidbody == null)
            Debug.LogError("Rigidbody �� ã�� �� �����ϴ�.");


    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                // ���� �����
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

        Vector3 velocity = _rigidbody.velocity; // �����Ѱ��� , �����°� �ƴϴ�.
        velocity.x = forwardSpeed;

        if (isFlap == true)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        // ���⼭ velocity �־��ֱ� 

        _rigidbody.velocity = velocity;


        // ������ �ƴ϶�, ������ �������� ���ڴ�
        //Mathf.Clamp �� 
        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10), -60, 60); //��길 �� �� 
        transform.rotation = Quaternion.Euler(0, 0, angle); // ��� �ϴ°� 
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
        deathCooldown = 1f; // �װ��� 1�� �ִٰ� ������ ������ϰ�

        animator.SetInteger("isDie", 1);
        gameManager.gameover();



    }
}