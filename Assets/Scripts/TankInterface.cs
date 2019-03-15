using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITank
{
    void Move(float speed);
    void Rotate(float rot);
    float GetRotation();
    void Primaryfire();
    RaycastHit CastRayCast(Vector3 direction, int layerMask);
}
