using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAY : MonoBehaviour
{
    public void LoadGameScene()
    {
        roadmovement.ResetSpeed(); // Reset the speed
        SceneManager.LoadScene(1); // Load the game scene by name
    }
}
