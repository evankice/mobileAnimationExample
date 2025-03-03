using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rigidbody;

    private Vector2 moveVector = new Vector2();
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void MoveWithVector(Vector2 aMoveVector)
    {
        moveVector = aMoveVector;
    }

    public void Attack()
    {
        anim.SetTrigger("attacking");
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(moveVector * moveSpeed);
        if(rigidbody.velocity != Vector2.zero)
        {
            anim.SetFloat("xSpeed",rigidbody.velocity.x);
            anim.SetFloat("ySpeed",rigidbody.velocity.y);
        }
    }

}
