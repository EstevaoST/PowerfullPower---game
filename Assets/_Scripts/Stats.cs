using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Stats {
    [Serializable]
    public struct StatsEntry
    {
        public StatsName name;
        public int value;
    }
    public enum StatsName
    {
        speed,
        size,
        gravity,
        damage,
        knockback,
        cooldown,
        rebound,
        explosion,
        recoil
    }

    // levels
    public int speed; // V
    public int size; // S
    public int gravity; // G
    public int damage; // D
    public int knockback; // K
    public int cooldown; // C
    public int rebound; // R
    public int explosion; // B
    public int recoil; //

    public float Speed          { get { return GetStatValue(StatsName.speed); } }
    public float Size           { get { return GetStatValue(StatsName.size); } }
    public float Gravity        { get { return GetStatValue(StatsName.gravity); } }
    public float Damage         { get { return GetStatValue(StatsName.damage); } }
    public float Knockback      { get { return GetStatValue(StatsName.knockback); } }
    public float Cooldown       { get { return GetStatValue(StatsName.cooldown); } }
    public float Rebound        { get { return GetStatValue(StatsName.rebound); } }
    public float Explosion      { get { return GetStatValue(StatsName.explosion); } }
    public float Recoil         { get { return GetStatValue(StatsName.recoil); } }
    public void SetStatLevel(StatsName s, int value)
    {
        switch (s)
        {
            case StatsName.speed: speed = value; break;
            case StatsName.size: size = value; break;
            case StatsName.gravity: gravity = value; break;
            case StatsName.damage: damage = value; break;
            case StatsName.knockback: knockback = value; break;
            case StatsName.cooldown: cooldown = value; break;
            case StatsName.rebound: rebound = value; break;
            case StatsName.explosion: explosion = value; break;
            case StatsName.recoil: recoil = value; break;
        }
    }
    public int GetStatLevel(StatsName s)
    {
        switch (s)
        {
            case StatsName.speed: return speed;
            case StatsName.size: return size;
            case StatsName.gravity: return gravity;
            case StatsName.damage: return damage;
            case StatsName.knockback: return knockback;
            case StatsName.cooldown: return cooldown;
            case StatsName.rebound: return rebound;
            case StatsName.explosion: return explosion;
            case StatsName.recoil: return recoil;
        }
        return 0;
    }
    public float GetStatValue(StatsName s)
    {
        switch (s)
        {
            case StatsName.speed: return 10 * speed * speed;
            case StatsName.size: return 0.25f * size;
            case StatsName.gravity: return (gravity-1) * gravity * GetStatValue(StatsName.speed) * 0.1f;
            case StatsName.damage: return 1 + 3 * damage;
            case StatsName.knockback: return 10000 * recoil * recoil * GetStatValue(StatsName.cooldown);
            case StatsName.cooldown: return Mathf.Pow(Mathf.Lerp(1.5f, 0.4f, cooldown/ 10.0f),2);
            case StatsName.rebound: return rebound - 1;
            case StatsName.explosion: return 3.1f * (explosion-1);
            case StatsName.recoil: return 1000 * recoil * recoil * GetStatValue(StatsName.cooldown);
        }
        return 0;
    }
    public static char GetStatChar(StatsName s)
    {
        switch (s)
        {
            case StatsName.speed: return 'V';
            case StatsName.size: return 'S';
            case StatsName.gravity: return 'G';
            case StatsName.damage: return 'D';
            case StatsName.knockback: return 'K';
            case StatsName.cooldown: return 'C';
            case StatsName.rebound: return 'R';
            case StatsName.explosion: return 'B';
            case StatsName.recoil: return 'F'; // what ???
        }
        return '?';
    }
    internal void Add(StatsEntry item)
    {
        SetStatLevel(item.name, GetStatLevel(item.name) + item.value);
    }
}
