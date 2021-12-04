using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Bob : MonoBehaviour
{

    void Update()
    {
        transform.localPosition = new Vector3(0, Mathf.Sin(Time.time * 5) * 0.1f, 0);
    }
}
