using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public float hp;
    public float armor;
    public float damage;
    public float attackCool;
    public int exp;
    public int gold;
}
