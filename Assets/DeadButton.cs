using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadButton : MonoBehaviour
{
    public string level = "Menu 1";
    public void Click()
    {
        Time.timeScale = 1;

        if (level == "")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(level);
        }
    }
}
