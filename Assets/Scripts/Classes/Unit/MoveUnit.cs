using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MoveUnit : IMove
{
    public bool IsMove { get; private set; }
    public float Speed { get; set; }

    public Vector3 PositionMove { get; private set; }

    public Transform Transform { get; private set; }

    private float heigthUnit;


    public MoveUnit(float speed, float heigthUnit, Transform transform)
    {
        this.heigthUnit = heigthUnit;
        Speed = speed;
        Transform = transform;
    }

    public void Execute()
    {
        if (IsMove)
        {
            Move();
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        LookAt(position);
        IsMove = true;
        PositionMove = position;
    }

    public void StopMove()
    {
        IsMove = false;
    }

    private void Move()
    {
        if (IsMove)
        {
            Transform.position += Transform.forward * Speed * Time.deltaTime;
            var distance = Vector3.Distance(Transform.position, PositionMove);
            if (distance < 0.1f)
            {
                StopMove();
            }
        }
    }

    private void LookAt(Vector3 position)
    {
        var positionLook = position.SetY(heigthUnit / 2.0f);
        Transform.LookAt(positionLook);
    }
}