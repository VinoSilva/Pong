using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D rbBody2D = null;

    [Header("Movement Variables")]
    [SerializeField]
    [Range(1.0f, 20.0f)]
    private float fMoveSpeed = 0.0f;

    private float yInput = 0.0f;

    [Header("Scriptable Variables")]
    [SerializeField]
    private BoolVariable pauseVariable;

    [Header("Game Event")]
    [SerializeField]
    private GameEvent pauseEvent = null;

    [SerializeField]
    private GameEvent resumeEvent = null;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pauseVariable.RuntimeValue)
        {
            Movement();
        }
    }

    private void Movement()
    {
        Vector2 moveVector =
            Vector2.up * yInput * Time.fixedDeltaTime * fMoveSpeed;

        if (yInput != 0.0f)
        {
            rbBody2D.MovePosition((Vector2)(transform.position) + moveVector);
        }
    }

    private void OnMove(InputValue value)
    {
        if (!pauseVariable.RuntimeValue)
        {
            Vector2 moveInput = value.Get<Vector2>();

            yInput = moveInput.y;
        }
    }

    private void OnPause(InputValue value)
    {
        // If paused, resume
        if (pauseVariable.RuntimeValue)
        {
            resumeEvent.Raise();
        }
        else
        {
            // If not paused, pause
            pauseEvent.Raise();
        }
    }
}
