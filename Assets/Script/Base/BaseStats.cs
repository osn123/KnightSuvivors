using UnityEngine;

public enum BonusType
{
    Bonus,Boost,
}

public enum StatsType
{
    Attack,Defense,MoveSpeed,
    HP,MaxHP,
    XP,MaxXP,
    PickUpRange,AliveTime,

    SpawnCount,
    SpawnTimerMin,
    SpawnTimerMax,
}

public class BaseStats
{
    public string Title;
    public int Id;
    public int Lv;
    public string Name;
    [TextArea] public string Description;
    public float Attack;
    public float Defense;
    public float HP;
    public float MaxHP;
    public float XP;
    public float MaxXP;
    public float MoveSpeed;
    public float PicUpRange;
    public float AliveTime;

}