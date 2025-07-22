using UnityEngine;

public class muteanimation : MonoBehaviour
{
    public GameObject panel;  // Reference to the panel GameObject

    void Start()
    {
        // Load the panel visibility state from PlayerPrefs
        bool isVisible = PlayerPrefs.GetInt("PanelVisible", 0) == 1;
        panel.SetActive(isVisible);
    }

    public void TogglePanel()
    {
        bool isActive = !panel.activeSelf;
        panel.SetActive(isActive);

        // Save the panel visibility state to PlayerPrefs
        PlayerPrefs.SetInt("PanelVisible", isActive ? 1 : 0);
        PlayerPrefs.Save();
    }
}
