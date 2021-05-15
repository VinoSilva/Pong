using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scriptable Variables")]
    [SerializeField]
    private BoolVariable pauseVariable = null;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void OnDestroy()
    {
        // Remove reference to this instance, so that it is collected by garbage collector
        if (this == _instance)
        {
            _instance = null;

            if (pauseVariable)
            {
                pauseVariable.RuntimeValue = false;
            }
        }
    }

    public void OnPaused()
    {
        pauseVariable.RuntimeValue = true;
    }

    public void OnResume()
    {
        pauseVariable.RuntimeValue = false;
    }
}
