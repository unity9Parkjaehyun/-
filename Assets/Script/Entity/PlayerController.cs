
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float moveSpeed = 5f;

    private AnimationHandler animationHandler;
    private Rigidbody2D _rigidBody2d;
    private SpriteRenderer spriteRenderer;
    private Camera maincamera;


    private Vector2 movementDirection;
    private Vector2 lookDirection;





    private void Awake()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationHandler = GetComponent<AnimationHandler>();

    }

    private void Start()
    {
        maincamera = Camera.main;
    }


    private void Update()
    {
        HandleInput();
        Rotate();
    }



    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;


        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = maincamera.ScreenToWorldPoint(mousePosition);

        lookDirection = (worldPosition - (Vector2)transform.position).normalized;

    }
    private void Move()
    {
        _rigidBody2d.velocity = movementDirection * moveSpeed;
        //"움직일 방향(movementDirection)에 속도(moveSpeed)를 곱해서 
        //Rigidbody2D의 속도로 설정 → 캐릭터 이동"      이동 공식 
        animationHandler.Move(movementDirection);
    }

    private void Rotate()   // 회전 공식. 외우기 
    {
        if (lookDirection == Vector2.zero) return;

        float rotZ =
        Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        // 각도 구함
        bool isLeft = Mathf.Abs(rotZ) > 90f; // 왼쪽인지 판단

        spriteRenderer.flipX = isLeft; // 왼쪽이면 스프라이트 뒤집음 
    }
}








