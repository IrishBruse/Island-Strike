using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleInstanceManager : MonoBehaviour
{
    static Dictionary<string , SingleInstanceManager> Instances = new Dictionary<string , SingleInstanceManager>();

    private void Awake()
    {
        if ( Instances.ContainsKey( gameObject.name ) == false )
        {
            DontDestroyOnLoad( gameObject );
            Instances.Add( gameObject.name , this );
        }
        else
        {
            Destroy( gameObject );
        }
    }
}
