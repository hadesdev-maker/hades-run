using UnityEngine;

public class ApplyMuteState : MonoBehaviour
{
    void Start()
    {
        // Apply the mute state when the scene starts
        if (mute.Instance != null)
        {
           mute.Instance.ApplyMuteState();
        }
    }
}
