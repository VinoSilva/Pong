using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("References Variable")]
    [SerializeField]
    private Rigidbody2D rbBody = null;

    [SerializeField]
    private TrailRenderer trailRenderer = null;

    [Header("Movement Variables")]
    [SerializeField]
    [Range(1.0f, 20.0f)]
    private float fBallSpeed = 1.0f;

    [SerializeField]
    [Range(0.1f,1.0f)]
    private float fTrailTime = 0.1f;

    private void OnDisable()
    {
        rbBody.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        SetNewVelocity(GetRandomVector2());
    }

    private Vector2 GetRandomVector2()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? Random.Range(0.5f, 1.0f) : Random.Range(-0.5f, -1.0f);
        float yVelocity = Random.Range(0, 2) == 0 ? Random.Range(0.0f, -1.0f) : Random.Range(0.0f, 1.0f);

        Vector2 velocityDir = new Vector2(xVelocity, yVelocity);

        return velocityDir;
    }

    private void SetNewVelocity(Vector2 velocityDir)
    {
        velocityDir = velocityDir.normalized;
        rbBody.velocity = velocityDir * fBallSpeed;
    }

    public void OnPause()
    {
        rbBody.simulated = false;
        trailRenderer.time = Mathf.Infinity;
    }

    public void OnResume()
    {
        rbBody.simulated = true;
        trailRenderer.time = fTrailTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Paddle")
        {
            float yDir =  transform.position.y >= other.gameObject.transform.position.y ? 1 : -1;

            Vector2 newDir = new Vector2(rbBody.velocity.x,yDir);
            newDir = newDir.normalized;

            SetNewVelocity(newDir);
        }
    }
}
