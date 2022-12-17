using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crab : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    static public bool StartMoving;
    public float speed;
    public float jumpForce;
    public float xMin, xMax;
    public float delta;
    public float distance;
    float move;
    public AudioSource audio;
    public GameObject gameOver;
    //bool isDragUp;
    Rigidbody2D body;
    Vector3 childPos;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartMoving = false;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PauseScript.isPause) return;
        Move();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), transform.position.y, 0);
        if (body.velocity.y < -0.1 )
        {
            body.velocity = new Vector3(body.velocity.x / 3,   body.velocity.y, 0);
        }
        //Debug.Log("Cam.y = " + Camera.main.transform.position.y);
        if (transform.position.y > Camera.main.transform.position.y)
        {
            //isDragUp = true;
            Camera.main.transform.position = new Vector3(0, transform.position.y, -10);
        }
        if (transform.position.y < Camera.main.transform.position.y - 7.14f)
        {
            Destroy(gameObject);
            //gameOver.SetActive(true);
        }
    }
    void OnDestroy()
    {
        //PauseScript.pauseGame();
        //PauseScript.Obj.SetActive(false);
        Debug.Log("end game");
        gameOver.SetActive(true);
    }


    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);
        bool dangLeoDoc=false;
        if (move * (transform.position.x - other.gameObject.transform.position.x) < 0) dangLeoDoc = true; 
        if (move == 0)
        {
            anim.SetInteger("state", 0);
            body.velocity = new Vector3(body.velocity.x / 400, -4, 0);
        }
        else if (other.gameObject.tag == "Jump")
        {
            if (!dangLeoDoc)
            {
                anim.SetInteger("state", 0);
                body.velocity = new Vector3(body.velocity.x / 400, -4, 0);
            }
            else
            {
                Jump();
                if (transform.position.y < other.transform.position.y + delta)
                {
                    if (move == 1 && transform.position.x < other.transform.position.x)
                    {

                        anim.SetInteger("state", 1);
                    }
                    else if (move == -1 && transform.position.x > other.transform.position.x)
                    {
                        anim.SetInteger("state", -1);
                    }
                }
            }
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Jump")
        {
            anim.SetInteger("state", 0);
            body.velocity = new Vector3(0.1f * move, -1, 0);
        }
    }
    void OnTriggerEenter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Jump")
        {
            bool dangLeoDoc = false;
            if (move * (transform.position.x - other.gameObject.transform.position.x) < 0) dangLeoDoc = true;
            if (!dangLeoDoc)
            body.velocity = new Vector3(0, -4, 0);
        }
    }
    void Idle()
    {
        anim.SetInteger("state", 0);
        body.velocity = new Vector3(body.velocity.x / 300, 0, 0);
    }

    void Jump()
    {
        //fish.AddForce(new Vector2(0, jumpForce));
        body.velocity = new Vector3(body.velocity.x, jumpForce, 0);
    }
    void Move()
    {
        move = Input.GetAxis("Horizontal");
        //Movement.move =
        //move = Movement.move;
        if (move != 0) StartMoving = true;
 
        body.velocity = new Vector3(move * speed, body.velocity.y, 0);
        if (body.velocity.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (body.velocity.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (-1f), transform.localScale.y, transform.localScale.z);
        }
    }
}