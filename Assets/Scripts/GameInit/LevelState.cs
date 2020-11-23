using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState
{
    Vector2 pos;
    bool isOpen;
    int stars;
    public bool IsOpen { get => isOpen; set => isOpen = value; }
    public int Stars { get => stars; set => stars = value; }
    public Vector2 Pos { get => pos; set => pos = value; }
}
