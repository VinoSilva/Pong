using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField]
    private GameObject prefBall;

    [SerializeField]
    private GameObject ball;

    private void Start()
    {
        StartCoroutine(ISpawnBall());
    }

    private void SpawnBall()
    {
        if (!ball)
        {
            ball =
                Instantiate(prefBall,
                Vector3.zero,
                prefBall.transform.rotation) as
                GameObject;
        }
    }

    private void Reset()
    {
        if (!ball.gameObject.activeSelf)
        {
            ball.transform.position = Vector3.zero;
            ball.SetActive(true);
        }
    }

    private IEnumerator ISpawnBall()
    {
        yield return new WaitForSecondsRealtime(3.0f);

        SpawnBall();
        Reset();

        yield return null;
    }
}
