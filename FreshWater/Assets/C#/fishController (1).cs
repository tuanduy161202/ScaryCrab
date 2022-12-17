using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fishController : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anim;
    static public bool startMoving=false;
    public float speed;
    public float jumpForce;
    public float xMin, xMax;
    public float delta;
    public float delta2;
    public float distance;
    float timeAudioPlay=1;
    float lastTimeAudioPlay=0;
    float move;
    Rigidbody2D body;
    bool isRight;

    AudioSource audio;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isRight = true;
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

        Move();
        if (body.velocity.y < -0.5)
        {
            body.velocity = new Vector3(body.velocity.x/3,1.1f*body.velocity.y, 0);
            
        }
    }
    //}
    void OnTriggerStay2D(Collider2D other)
    {
        if (move == 0)
        {
            anim.SetInteger("state", 0);
            body.velocity = new Vector3(body.velocity.x / 400, -3, 0);
        }
        else if (other.gameObject.tag == "Jump" && transform.position.y < other.transform.position.y + delta)
        {
            if (move==1 && transform.position.x < other.transform.position.x)
            {
                Jump();
                anim.SetInteger("state", 1);
            } 
            else if (move == -1 && transform.position.x > other.transform.position.x)
            {
                Jump();
                anim.SetInteger("state", -1);
            }
        }
        if (transform.position.y > other.transform.position.y + delta2)
        {
            anim.SetInteger("state", 0);
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Jump")
        {
            Idle();
        }
    }
    //void OnColiisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Item")
    //    {
    //        Destroy(other);
    //        Destroy(Instantiate(boom, other.gameObject.transform.position + new Vector3(-0.32f, 0, 0), Quaternion.identity), timeDestroyItem);

    //    }
    //}
    void Idle()
    {
        anim.SetInteger("state",0);
        body.velocity = new Vector3(body.velocity.x/400, 0, 0);
    }

    void Jump()
    {
        //fish.AddForce(new Vector2(0, jumpForce));
        body.velocity = new Vector3(body.velocity.x, jumpForce, 0);
    }
    void Move()
    {
        
        move = Input.GetAxis("Horizontal");
        if (move!=0 && Time.time > (timeAudioPlay + lastTimeAudioPlay))
        {
            audio.Play();
            lastTimeAudioPlay = Time.time;
        }
        if (move != 0) startMoving = true;
        body.velocity = new Vector3(move * speed, body.velocity.y, 0);
        if (body.velocity.x > 0 && !isRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isRight = true;
        }
        if (body.velocity.x < 0 && isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isRight = false;
        }
    }
}

