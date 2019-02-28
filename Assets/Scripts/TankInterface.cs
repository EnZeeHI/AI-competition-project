using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITank
{
    void MoveForward();
    void MoveBackwards();
    void RotateLeft();
    void RotateRight();
    Vector3 GetRotation();
    Vector2 GetPosition();
    int GetHealth();
    void PrimraryFire();

    
}

