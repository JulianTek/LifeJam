using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "LifeJam/Create new crop")]
public class Crop : ScriptableObject
{
    public string Name;
    public Sprite[] Sprites;
    public Sprite InventorySprite;
    public float TimeToGrow;
    public float DamagePerHit;
    public float Duration;
    public DamageType DamageType;
}

public enum DamageType
{
    Projectile,
    Contact,
    Melee
}
