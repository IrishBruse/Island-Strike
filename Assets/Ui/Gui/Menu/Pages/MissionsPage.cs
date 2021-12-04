using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionsPage : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Mission1()
    {
        SceneManager.LoadScene("Mission1");
    }

    public void Mission2()
    {
        SceneManager.LoadScene("Mission2");
    }

    public void Mission3()
    {
        SceneManager.LoadScene("Mission3");
    }

    public void Endless()
    {
        SceneManager.LoadScene("Endless");
    }
}
