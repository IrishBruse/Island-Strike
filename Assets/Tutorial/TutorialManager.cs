using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public TMP_Text text;

    public Health player;
    public GunController playerGun;
    public GameObject enemyPlane;
    public GameObject enemyTurret;

    private void Start()
    {
        player.health = 200;
        StartCoroutine("Tutorial");
    }

    IEnumerator Tutorial()
    {
        yield return new WaitForEndOfFrame();
        playerGun.bombAmmo = 0;


        text.text = "Use A and D or arrow keys to\n turn left and right.";
        yield return new WaitForSeconds(5);
        text.text = "";
        yield return new WaitForSeconds(2);


        text.text = "Hold down left click to\n fire main weapon.";
        yield return new WaitForSeconds(7);
        text.text = "";
        yield return new WaitForSeconds(4);


        text.text = "When you run out of ammo,\n hold down A or D and turn the plane\n in a full circle with out stopping to reload";
        yield return new WaitForSeconds(8);
        text.text = "";
        yield return new WaitForSeconds(20);

        text.text = "Now try fighting this plane good luck";
        yield return new WaitForSeconds(5);
        text.text = "";
        enemyPlane.SetActive(true);

        while (enemyPlane.activeSelf)
        {
            yield return new WaitForSeconds(2);
        }

        text.text = "Well done!";
        yield return new WaitForSeconds(3);

        text.text = "Use right click to drop a bombs";
        playerGun.bombAmmo = 99;
        yield return new WaitForSeconds(5);
        text.text = "";

        yield return new WaitForSeconds(5);
        text.text = "next try taking out this turret\n it's over by the village";
        yield return new WaitForSeconds(5);
        text.text = "";

        enemyTurret.SetActive(true);


        while (enemyTurret.activeSelf)
        {
            yield return new WaitForSeconds(2);
        }

        text.text = "Well done!";
        yield return new WaitForSeconds(5);
        text.text = "Now you are ready to take on your first mission";

        yield return new WaitForSeconds(5);
        text.text = "";

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Menu 1");
    }
}
