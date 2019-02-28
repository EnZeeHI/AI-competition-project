using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITankMovement<T>
{
    void MoveForward(T Body);
    void MoveBackwards(T Body);
    void RotateLeft(T Body);
    void RotateRight(T Body);
    
}
public interface ITankAttacks
{
    void PrimraryFire();
}

