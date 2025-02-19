using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float moveSpeed = 5;
    private Rigidbody2D rigidbody;

    private Vector2 moveVector = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveWithVector(Vector2 aMoveVector)
    {
        moveVector = aMoveVector;
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(moveVector * moveSpeed);
    }

}
