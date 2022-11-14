using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float reloadDelay = 0.5f;

    // Audio
    [SerializeField] AudioClip crashSFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            PlayerController player = FindObjectOfType<PlayerController>();
            if (!player.Crashed)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
            }

            player.DisableControls();
            Invoke("ReloadScene", reloadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
