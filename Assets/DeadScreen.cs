using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    public GameObject won;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (won.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
