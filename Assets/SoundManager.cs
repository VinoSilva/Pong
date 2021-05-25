using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance{
        get {
            return _instance;
        }
    }

    [Header("References Variable")]
    [SerializeField]
    private AudioSource audioSource = null;

    private void Awake(){
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
        }
        else{
            _instance = this;
        }
    }

    public void PlayOneShot(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }
}
