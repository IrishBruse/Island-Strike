using UnityEngine;

public class MainPage : MonoBehaviour
{
    PageManager pageManager;
    private void Awake()
    {
        pageManager = GetComponentInParent<PageManager>();
    }

    public void Singleplayer()
    {
        pageManager.ChangePage(PageDirection.Up);
    }

    public void Settings()
    {
        pageManager.ChangePage(PageDirection.Down);
    }

    public void Quit()
    {
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            Application.Quit();
        }
    }
}
