using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public float Speed;
    public float PermanentSpeed;
    public float WheelAngle;
    public float RotationUnit;
    public float BoostSpeed;
    public bool CanSpeedBoost;
    public bool CanDestroy;

}
