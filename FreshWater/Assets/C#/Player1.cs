using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    Animator animator;
    static public bool StartMoving;
    public float speed;
    public float xMin;
    public float xMax;
    public float jumpForce;
    static public bool isJump;
    float move;
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isJump = false;
        StartMoving = false;
        //Physics2D.gravity = new Vector3(9.8f, 0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //isTrigger = false;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y, 0);
        move = Input.GetAxis("Horizontal")*speed;
        if (move != 0) StartMoving = true;
        //Debug.Log(move);
        animator.SetFloat("speedX", move);
        player.velocity = new Vector3(move * speed, player.velocity.y, 0);
        if (move == 0) player.gravityScale = 1f;
        if (isJump) player.gravityScale = 1f;
    }
    void OnTriggerExit2D(Collider2D hitInfor)
    {
        player.gravityScale = 1f;
        player.velocity = new Vector3(player.velocity.x, 0, 0);
        //transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void OnTriggerStay2D(Collider2D hitInfor)
    {
        Debug.Log(hitInfor.tag);
        if (hitInfor.tag == "Line" && !isJump)
        {
            if (move > 0) transform.eulerAngles = new Vector3(0, 0, 90);
            else if (move < 0) transform.eulerAngles = new Vector3(0, 0, -90);
            jump();
        }
    }
    void OnCollisionStay2D(Collision2D hitInfor)
    {
        Debug.Log(hitInfor.gameObject.tag);
        if (hitInfor.gameObject.tag != "Line")
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void jump()
    {
        Debug.Log("Jump");
        player.gravityScale = 0f;
        player.velocity = new Vector2(player.velocity.x, Mathf.Abs(move)*jumpForce);
    }


}
