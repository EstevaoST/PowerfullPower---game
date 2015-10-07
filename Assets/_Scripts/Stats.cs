using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class Stats {
    [Serializable]
    public struct StatsEntry
    {
        public StatsName name;
        public float value;
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


    public float speed; // V
    public float size; // S
    public float gravity; // G
    public int damage; // D
    public float knockback; // K
    public float cooldown; // C
    public int rebound; // R
    public float explosion; // B
    public float recoil; //


    public void SetStat(StatsName s, float value)
    {
        switch (s)
        {
            case StatsName.speed: speed = value; break;
            case StatsName.size: size = value; break;
            case StatsName.gravity: gravity = value; break;
            case StatsName.damage: damage = (int)value; break;
            case StatsName.knockback: knockback = value; break;
            case StatsName.cooldown: cooldown = value; break;
            case StatsName.rebound: rebound = (int)value; break;
            case StatsName.explosion: explosion = value; break;
            case StatsName.recoil: recoil = value; break;
        }
    }
    public float GetStat(StatsName s)
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
    public static float GetStatValue(StatsName s, int level)
    {
        switch (s)
        {
            case StatsName.speed: return 100 * level;
            case StatsName.size: return 5 + 2 * level;
            case StatsName.gravity: return 0.3f * level;
            case StatsName.damage: return 1 + 3 * level;
            case StatsName.knockback: return 100 * level;
            case StatsName.cooldown: return Mathf.Lerp(2, 0.1f, level / 10.0f);
            case StatsName.rebound: return level - 1;
            case StatsName.explosion: return 10 * level;
            case StatsName.recoil: return 100 * level; // what ???
        }
        return 0;
    }

    internal void Add(StatsEntry item)
    {
        SetStat(item.name, GetStat(item.name) + item.value);
    }
}
