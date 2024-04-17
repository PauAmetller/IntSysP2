using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpeedModifier : MonoBehaviour
{
    public float sheepSpeed;

    private void Start()
    {
        sheepSpeed = 5;
    }
    public float UpdateMayMachineMovementSpeed(float movementSpeed)
    {
        if (movementSpeed > 10)
        {
            movementSpeed -= Time.deltaTime;
        }
        return movementSpeed;
    }

    public void updateSheepSpeed()
    {
        if (sheepSpeed < 15)
        {
            sheepSpeed += Time.deltaTime;// / 4;
        }
    }

}
