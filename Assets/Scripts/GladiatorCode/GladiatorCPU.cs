using UnityEngine;

public class GladiatorCPU : Gladiator
{
    protected CombatAI gParadigm; //Defines the CPU gladiator's current strategy.
    protected StrategyShift gShift; //Defines if and when the CPU gladiator shifts strategy.

    public GladiatorCPU()
    {
        SetCombatAI();
        SetStrategy();
        this.HP = 10;
    }

    public GladiatorCPU(string gladName) : base(gladName)
    {
    }

    public CombatAI Paradigm
    { get { return gParadigm; } }

    public StrategyShift Shift
    { get { return gShift; } }

    private void SetCombatAI()
    {
        int rngCombat = Random.Range(1, 5);
        switch (rngCombat)
        {
            case 1:
                gParadigm = new AttackerAI();
                this.GladName = "Devil-Hunting Gladiator";
                break;
            case 2:
                gParadigm = new CounterAI();
                this.GladName = "Expeditioning Gladiator";
                break;
            case 3:
                gParadigm = new BalancedAI();
                this.GladName = "Tarnished Gladiator";
                break;
            case 4:
                gParadigm = new DefensiveAI();
                this.GladName = "Stalwart Gladiator";
                break;
            default:
                break;
        }
    }

    public void SetCombatAI(string aiChange)
    {
        switch (aiChange)
        {
            case "attacker":
                gParadigm = new AttackerAI();
                gShift.ParadigmShifted = true;
                break;
            case "counter":
                gParadigm = new CounterAI();
                gShift.ParadigmShifted = true;
                break;
            case "balanced":
                gParadigm = new BalancedAI();
                gShift.ParadigmShifted = true;
                break;
            case "defensive":
                gParadigm = new DefensiveAI();
                gShift.ParadigmShifted = true;
                break;
            default:
                break;
        }
    }

    private void SetStrategy()
    {
        int rngStrat = Random.Range(1, 5);
        switch (rngStrat)
        {
            case 1:
                gShift = new AdamantStrat();
                break;
            case 2:
                gShift = new DefensiveStrat();
                break;
            case 3:
                gShift = new ExploitStrat();
                break;
            case 4:
                gShift = new GamblerStrat();
                break;
            default:
                break;
        }
    }

    public string CPUChooseAction()
    {
        float rngAction = Random.Range(0, 100);
        if (rngAction <= gParadigm.StrikeLimit)
        {
            return "strike";
        }
        else if (rngAction <= gParadigm.ThrustLimit)
        {
            return "thrust";
        }
        else if (rngAction <= gParadigm.ParryLimit)
        {
            return "parry";
        }
        else return "block";
    }
}
