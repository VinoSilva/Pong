using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [Header("Prefab variables")]
    [SerializeField]
    private GameObject paddlePrefab = null;

    [SerializeField]
    private GameObject aiPrefab = null;

    [Header("Spawn points")]
    [SerializeField]
    private Vector2 playerOneSpawnPoint = Vector2.zero;

    [SerializeField]
    private Vector2 playerTwoSpawnPoint = Vector2.zero;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector3)playerOneSpawnPoint, 1.0f);
        Gizmos.DrawWireSphere((Vector3)playerTwoSpawnPoint, 1.0f);
    }

    private void Start()
    {
        GameObject paddle = Instantiate(paddlePrefab,playerOneSpawnPoint,paddlePrefab.transform.rotation) as GameObject;
        GameObject ai =Instantiate(aiPrefab,playerTwoSpawnPoint,aiPrefab.transform.rotation)  as GameObject;

        paddle.SetActive(true);
        ai.SetActive(true);
    }
}
