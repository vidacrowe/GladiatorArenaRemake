using System.Collections.Generic;
using UnityEngine;

interface IShift
{
    string Analyze();
    void RememberPlayersMove(string battleactions);
}

public abstract class StrategyShift : MonoBehaviour, IShift
{
    protected int pStrikeCount = 0, pThrustCount = 0, pParryCount = 0, pBlockCount = 0;
    protected bool pardigmShifted = false;

    public bool ParadigmShifted
    { get { return pardigmShifted; } set { pardigmShifted = value; } }

    public abstract string Analyze(); //GladiatorCPU analyzes the battle and decides what to do.

    public void RememberPlayersMove(string battleactions) //GladiatorCPU takes note of what the player does.
    {
        switch (battleactions)
        {
            case "strike":
                pStrikeCount++;
                break;
            case "thrust":
                pThrustCount++;
                break;
            case "parry":
                pParryCount++;
                break;
            case "block":
                pBlockCount++;
                break;
            default:
                break;
        }
    }
}

class AdamantStrat : StrategyShift //CombatAI does not change.
{
    public override string Analyze()
    {
        return "default";
    }
}

class DefensiveStrat : StrategyShift //Switches CombatAI to minimize damage.
{
    public override string Analyze()
    {
        if (pStrikeCount >= 3)
            return "defensive";
        else if (pParryCount >= 3)
            return "counter";
        else if (pThrustCount >= 3)
            return "counter";
        else
            return "default";
    }
}

class ExploitStrat : StrategyShift //Switches CombatAI to maximize damage.
{
    public override string Analyze()
    {
        if (pStrikeCount >= 4)
            return "counter";
        else if (pThrustCount >= 4)
            return "attacker";
        else if (pParryCount >= 4)
            return "balanced";
        else if (pBlockCount >= 4)
            return "thrust";
        else
            return "default";
    }
}

class GamblerStrat : StrategyShift //Switches CombatAI to BalancedAI.
{
    public override string Analyze()
    {
        if (pStrikeCount + pThrustCount + pParryCount + pBlockCount > 5)
            return "balanced";
        else
            return "default";
    }
}