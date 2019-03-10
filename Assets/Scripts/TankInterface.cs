using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITank
{
    void Move(int speed);
    void Rotate(int rot);
    decimal GetRotation();
    Vector2 GetPosition();
    int GetHealth();
    void PrimraryFire();
}

