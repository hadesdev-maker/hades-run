using UnityEngine;
using UnityEngine.SceneManagement;

public class frontend : MonoBehaviour
{
    public void LoadHomeScreen()
    {
        roadmovement.ResetSpeed(); // Reset the speed
        SceneManager.LoadScene(0); // Load the home screen scene by name
    }
}
