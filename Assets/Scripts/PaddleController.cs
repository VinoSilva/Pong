using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D rbBody2D = null;

    [Header("Movement Variables")]
    [SerializeField]
    [Range(1.0f,20.0f)]
    private float fMoveSpeed = 0.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float yInput = Input.GetAxisRaw("Vertical"); 
        Vector2 moveVector = Vector2.up * yInput * Time.fixedDeltaTime * fMoveSpeed;

        if(yInput != 0.0f){
            rbBody2D.MovePosition((Vector2)(transform.position) + moveVector);
        }
    }
}
