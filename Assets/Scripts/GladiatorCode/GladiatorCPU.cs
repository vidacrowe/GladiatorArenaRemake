using UnityEngine;

public class GladiatorCPU : Gladiator
{
    protected CombatAI gParadigm; //Defines the CPU gladiator's current strategy.
    protected StrategyShift gShift; //Defines if and when the CPU gladiator shifts strategy.

    public GladiatorCPU()
    {
        SetInitialCombatAI();
        SetStrategy();
    }

    public GladiatorCPU(string gladName) : base(gladName)
    {
    }

    //public CombatAI Paradigm
    //{ get { return gParadigm; } }

    //public StrategyShift Shift
    //{ get { return gShift; } }

    public void SetInitialCombatAI()
    {
        int rngCombat = Random.Range(1, 5);
        switch (rngCombat)
        {
            case 1:
                gParadigm = new AttackerAI();
                this.GladName = "Warrior Gladiator";
                break;
            case 2:
                gParadigm = new CounterAI();
                this.GladName = "Expeditioning Gladiator";
                break;
            case 3:
                gParadigm = new BalancedAI();
                this.GladName = "Zenless Gladiator";
                break;
            case 4:
                gParadigm = new DefensiveAI();
                this.GladName = "Tarnished Gladiator";
                break;
            default:
                break;
        }
    }

    public void SetStrategy()
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
