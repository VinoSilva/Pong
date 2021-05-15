using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxController : MonoBehaviour
{
    [Header("References Variable")]
    [SerializeField]
    private GameEvent gameEvent = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.SetActive(false);
            gameEvent.Raise();
        }
    }
}
