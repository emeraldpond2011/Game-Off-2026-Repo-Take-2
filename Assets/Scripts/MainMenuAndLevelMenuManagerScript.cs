using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAndLevelMenuManagerScript : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
