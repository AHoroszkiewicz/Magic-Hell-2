using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats", fileName = "New stats")]
public class StatsSO : ScriptableObject
{
    public float health;
    public float damage;
    public float baseFireRate;
    public int level = 1;
}
