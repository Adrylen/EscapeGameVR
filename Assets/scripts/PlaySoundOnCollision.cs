using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioSource sound;
    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    // Mettre un collider sur chacun des objets
    void OnCollisionEnter(Collision test)
    {
        if (test.gameObject.CompareTag("test"))
        {
            sound.Play();
        }
    }
}
