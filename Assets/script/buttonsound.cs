using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip buttonClickSound;  // Reference to the button click sound
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this GameObject");
        }
    }

    public void PlaySound()
    {
        Debug.Log("PlaySound method called");
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing");
        }
    }
}
