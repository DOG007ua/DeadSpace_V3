using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove : IComponent
{
    Transform Transform { get; }
    Vector3 PositionMove { get; }
    bool IsMove { get; }
    float Speed { get; }    
    void MoveToPosition(Vector3 position);
    void StopMove();

}
