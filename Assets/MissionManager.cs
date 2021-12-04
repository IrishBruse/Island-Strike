using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour
{
    public bool isTutorial = false;

    public List<GameObject> turrets = new List<GameObject>();
    public List<GameObject> planes = new List<GameObject>();

    public Text turretsUI;
    public Text planesUI;

    public GameObject missionWin;

    private void Awake()
    {

    }

    private void Update()
    {

        int turretsLeft = 0;
        int planesLeft = 0;

        foreach (var item in turrets)
        {
            if (item.activeSelf)
            {
                turretsLeft++;
            }
        }

        foreach (var item in planes)
        {
            if (item.activeSelf)
            {
                planesLeft++;
            }
        }

        turretsUI.text = turretsLeft + "/" + turrets.Count;
        planesUI.text = planesLeft + "/" + planes.Count;

        if (isTutorial)
        {
            return;
        }

        if (turretsLeft == 0 && planesLeft == 0)
        {
            StartCoroutine("EndGame");
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1);
        missionWin.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu 1");
    }

}
