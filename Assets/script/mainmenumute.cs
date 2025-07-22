using UnityEngine;
using UnityEngine.UI;

public class mainmenumute : MonoBehaviour
{
    public Button muteButton;  // Reference to the mute button

    void Start()
    {
        if (mute.Instance != null)
        {
            mute.Instance.SetMuteButton(muteButton);
            // Set the initial button text or state here if needed
        }
    }
}
