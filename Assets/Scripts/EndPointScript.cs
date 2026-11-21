using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{
    public int nextScene = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(nextScene);
    }
}
