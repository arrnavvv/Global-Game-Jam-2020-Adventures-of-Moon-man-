using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    int moveDirection = 0;
    public float speed = 10f;
    private Animator anim;
    bool onTop = false;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        customMovementInput();
        GravityChange();
    }

    private void FixedUpdate()
    {
        if (moveDirection == 1)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        else if (moveDirection == -1)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }

    }

    private void GravityChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.gravityScale = -1 * rb.gravityScale;
            RotationOnGravityChange();
        }
    }

    private void RotationOnGravityChange()
    {
        if (onTop == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        onTop = !onTop;
    }

    private void customMovementInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
            anim.SetBool("walking", true);
            if (onTop == false)
                rb.transform.localScale = new Vector2(0.4271759f, 0.4271759f);
            else
                rb.transform.localScale = new Vector2(-0.4271759f, transform.localScale.y);

        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
            anim.SetBool("walking", true);
            if (onTop == false)
                rb.transform.localScale = new Vector2(-0.4271759f, 0.4271759f);
            else
                rb.transform.localScale = new Vector2(0.4271759f, transform.localScale.y);
        }
        else
        {
            moveDirection = 0;
            anim.SetBool("walking", false);
        }
    }
}
