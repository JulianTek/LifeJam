using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public float TimeToGrow;
    public float DamagePerHit;
    public DamageType DamageType;
}

public enum DamageType
{
    Projectile,
    Contact,
    Melee
}
