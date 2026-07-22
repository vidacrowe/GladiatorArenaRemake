using UnityEngine;

public abstract class CombatAI
{
    protected float f_StrikeLimit, f_ThrustLimit, f_ParryLimit, f_BlockLimit;
    protected int t_CombatType;

    public float StrikeLimit
    { get { return f_StrikeLimit; } }

    public float ThrustLimit
    { get { return f_ThrustLimit; } }

    public float ParryLimit
    { get { return f_ParryLimit; } }

    public float BlockLimit
    { get { return f_BlockLimit; } }

    public int CombatType
    { get { return t_CombatType; } }

    protected void SetRNGRange(float strikePercent, float thrustPercent, float parryPercent, float blockPercent)
    {
        f_StrikeLimit = strikePercent;
        f_ThrustLimit = strikePercent + thrustPercent;
        f_ParryLimit = strikePercent + thrustPercent + parryPercent;
        f_BlockLimit = strikePercent + thrustPercent + parryPercent + blockPercent;
    }
}

class AttackerAI : CombatAI
{
    public AttackerAI()
    {
        SetRNGRange(30, 30, 20, 20);
        t_CombatType = 1;
    }
}

class CounterAI : CombatAI
{
    public CounterAI()
    {
        SetRNGRange(20, 30, 30, 20);
        t_CombatType = 2;
    }
}

class BalancedAI : CombatAI
{
    public BalancedAI()
    {
        SetRNGRange(25, 25, 25, 25);
        t_CombatType = 3;
    }
}

class DefensiveAI : CombatAI
{
    public DefensiveAI()
    {
        SetRNGRange(20, 20, 20, 40);
        t_CombatType = 4;
    }
}
