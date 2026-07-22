using System.Collections.Generic;
using UnityEngine;

interface IShift
{
    string Analyze();
    void RememberPlayersMove(string battleactions);
}

public abstract class StrategyShift : IShift
{
    protected int p_StrikeCount = 0, p_ThrustCount = 0, p_ParryCount = 0, p_BlockCount = 0, t_StrategyType;
    protected bool b_PardigmShifted = false;

    public bool ParadigmShifted
    { get { return b_PardigmShifted; } set { b_PardigmShifted = value; } }

    public int StrategyType
    { get { return t_StrategyType; } }

    public abstract string Analyze(); //GladiatorCPU analyzes the battle and decides what to do.

    public void RememberPlayersMove(string battleactions) //GladiatorCPU takes note of what the player does.
    {
        switch (battleactions)
        {
            case "strike":
                p_StrikeCount++;
                break;
            case "thrust":
                p_ThrustCount++;
                break;
            case "parry":
                p_ParryCount++;
                break;
            case "block":
                p_BlockCount++;
                break;
            default:
                break;
        }
    }
}

class AdamantStrat : StrategyShift //CombatAI does not change.
{
    public AdamantStrat()
    {
        t_StrategyType = 1;
    }

    public override string Analyze()
    {
        return "default";
    }
}

class DefensiveStrat : StrategyShift //Switches CombatAI to minimize damage.
{
    public DefensiveStrat()
    {
        t_StrategyType = 2;
    }

    public override string Analyze()
    {
        if (p_StrikeCount >= 3)
            return "defensive";
        else if (p_ParryCount >= 3)
            return "counter";
        else if (p_ThrustCount >= 3)
            return "counter";
        else
            return "default";
    }
}

class ExploitStrat : StrategyShift //Switches CombatAI to maximize damage.
{
    public ExploitStrat()
    {
        t_StrategyType= 3;
    }

    public override string Analyze()
    {
        if (p_StrikeCount >= 4)
            return "counter";
        else if (p_ThrustCount >= 4)
            return "attacker";
        else if (p_ParryCount >= 4)
            return "balanced";
        else if (p_BlockCount >= 4)
            return "thrust";
        else
            return "default";
    }
}

class GamblerStrat : StrategyShift //Switches CombatAI to BalancedAI.
{
    public GamblerStrat()
    {
        t_StrategyType = 4;
    }

    public override string Analyze()
    {
        if (p_StrikeCount + p_ThrustCount + p_ParryCount + p_BlockCount > 5)
            return "balanced";
        else
            return "default";
    }
}