using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<DialougeManager>().activeD && !FindObjectOfType<WarpManager>().isWarping)
        {
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if(movement_vector != Vector2.zero)
            {
                 anim.SetBool("isWalking", true);
                 anim.SetFloat("input_x", movement_vector.x);
                 anim.SetFloat("input_y", movement_vector.y);
            } 
            else 
            {
                 anim.SetBool("isWalking", false);
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * speed);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
