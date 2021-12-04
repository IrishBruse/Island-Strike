using System;
using UnityEngine;

[Serializable]
public class Page : MonoBehaviour
{
    public Vector2Int pagePosition;
}

public enum PageDirection
{
    Up,
    Down,
    Left,
    Right
}