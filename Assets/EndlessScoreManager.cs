using UnityEngine;
using UnityEngine.UI;

public class EndlessScoreManager : MonoBehaviour
{
    public Text planes;
    public Text turrets;

    public int turretKills;
    public int planeKills;

    public static EndlessScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        turrets.text = turretKills + "";
        planes.text = planeKills + "";
    }
}
