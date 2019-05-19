using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        SceneManager.LoadScene("Race");
    }
}
