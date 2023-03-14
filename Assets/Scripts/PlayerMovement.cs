
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;

    private int score=0;
    public static int finalscore;
    public LayerMask groundLayerMask;

    public bool isGrounded;
    public float playerSpeed=2;
    public float jumpForce;
    public float raycastLength ;



    [SerializeField] TextMeshProUGUI scoretxt;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=new Vector2(horizontal*playerSpeed,rb.velocity.y);
        horizontal= Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        isGrounded=Physics2D.Raycast(transform.position,Vector2.down,raycastLength,groundLayerMask);
        Debug.DrawRay(transform.position,Vector3.down*raycastLength,Color.green);
        anim.SetBool("isGrounded", isGrounded);

        if (rb.velocity.x != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Coin")
        {
            score += 1;
            scoretxt.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        if (other.tag == "finish")
        {
            finalscore = score;
            SceneManager.LoadScene("End");
        }
        if (other.tag == "Restart")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
