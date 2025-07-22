using UnityEngine;
using UnityEngine.UI;

public class mute : MonoBehaviour
{
    public static mute Instance;  // Singleton instance
    private bool isMuted = false;  // State to track if the sound is muted or not

    // Public property to access the mute state
    public bool IsMuted
    {
        get { return isMuted; }
    }

    void Awake()
    {
        // Implementing the singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Set the initial volume based on the mute state
        ApplyMuteState();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;  // Toggle the mute state
        ApplyMuteState();
    }

    public void ApplyMuteState()
    {
        AudioListener.volume = isMuted ? 0 : 1;
    }

    public void SetMuteButton(Button button)
    {
        button.onClick.RemoveAllListeners(); // Remove any existing listeners
        button.onClick.AddListener(ToggleMute); // Add the ToggleMute listener
    }
}
