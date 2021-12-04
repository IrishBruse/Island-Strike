using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    public bool isTutorial = false;
    public Bounds mapBounds;
    Volume postp;
    public GameObject text;
    public Text timertext;

    float timer;

    private void Awake()
    {
        postp = GetComponent<Volume>();
    }

    private void Update()
    {
        if (!mapBounds.Contains(transform.position))
        {
            postp.weight = Mathf.MoveTowards(postp.weight, 1f, 0.02f);
            timer += Time.deltaTime;
            timer = Mathf.Min(timer, 5);
            timertext.text = Mathf.FloorToInt(6f - timer).ToString();
            if (timer >= 5)
            {
                if (isTutorial)
                {
                    gameObject.transform.position = Vector3.zero;
                }
                else
                {
                    text.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    FindObjectOfType<DeadScreen>(true).gameObject.SetActive(true);
                    return;
                }
            }
        }
        else
        {
            timer = 0;
            postp.weight = Mathf.MoveTowards(postp.weight, 0f, 0.02f);
        }

        text.gameObject.SetActive(!mapBounds.Contains(transform.position));
    }
}
