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
    [Range(0.0f,1.0f)]
    private float fTrailTime = 0.0f;

    private void OnDisable()
    {
        rbBody.velocity = Vector2.zero;
    }

    private void OnEnable()
    {
        RandomizeVelocity();
    }

    private Vector2 GetRandomVector2()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? Random.Range(0.1f, 1.0f) : Random.Range(-0.1f, -1.0f);
        float yVelocity = Random.Range(0, 2) == 0 ? Random.Range(0.0f, -1.0f) : Random.Range(0.0f, 1.0f);

        Vector2 velocityDir = new Vector2(xVelocity, yVelocity);

        return velocityDir;
    }

    private void RandomizeVelocity()
    {
        Vector2 velocityDir = GetRandomVector2();
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
}
