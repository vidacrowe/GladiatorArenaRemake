using UnityEngine;

static class StaticDialog
{
    public static string CPUStrategyAIText(int strategyType)
    {
        string strategyTypeText = string.Empty;
        switch (strategyType)
        {
            case 1:
                strategyTypeText = "Your opponent has a determined look in their eyes...";
                break;
            case 2:
                strategyTypeText = "Your opponent is cautiously looking at you...";
                break;
            case 3:
                strategyTypeText = "Your opponent is eyeing your movements...";
                break;
            case 4:
                strategyTypeText = "Your opponent is feeling relaxed...";
                break;
        }
        return strategyTypeText;
    }

    public static string CPUCombatAIShiftText(int combatType, string p2Name)
    {
        string combatTypeText = string.Empty;
        switch (combatType)
        {
            case 1:
                combatTypeText = string.Format("Your eyes met as {0} held their blade forward...", p2Name);
                break;
            case 2:
                combatTypeText = string.Format("There was a glint in their eyes as {0} raised their blade...", p2Name);
                break;
            case 3:
                combatTypeText = string.Format("{0} smirked... Who knows what they'll do?", p2Name);
                break;
            case 4:
                combatTypeText = string.Format("{0} grunted as they take a defensive stance...", p2Name);
                break;
        }
        return combatTypeText;
    }

    public static string TurnOutcomeText(string actionKey, string p1Name, string p2Name)
    {
        string turnOutcomeText = string.Empty;
        switch (actionKey)
        {
            //Text for No Damage:
            case "strikeblock":
                turnOutcomeText = string.Format("{1} blocked {0}'s Strike!\n\nNo Damage!", p1Name, p2Name);
                break;
            case "parryparry":
                turnOutcomeText = "Both were ready to Parry! But nothing happened!\n\nNo Damage!";
                break;
            case "parryblock":
                turnOutcomeText = string.Format("{0} readied to Parry, but {1} used Block!\n\nNo Damage!", p1Name, p2Name);
                break;
            case "blockstrike":
                turnOutcomeText = string.Format("{0} blocked {1}'s Strike!\n\nNo Damage!", p1Name, p2Name);
                break;
            case "blockparry":
                turnOutcomeText = string.Format("{1} readied to Parry, but {0} used Block!\n\nNo Damage!", p1Name, p2Name);
                break;
            case "blockblock":
                turnOutcomeText = "Both were ready to Block! But nothing happened!\n\nNo Damage!";
                break;
            
            //Text for 1 Damage to All:
            case "strikestrike":
                turnOutcomeText = "Both attacked with a Strike!\n\nBoth gladiators take 1 damage!";
                break;
            case "thrustthrust":
                turnOutcomeText = "Both attacked with a Thrust!\n\nBoth gladiators take 1 damage!";
                break;

            //Text for 1 Damage to Player 2:
            case "parrythrust":
                turnOutcomeText = string.Format("{1} lunged with a Thrust, but {0} Parried the hit!\n\n{1} takes 1 damage!", p1Name, p2Name);
                break;

            //Text for 1 Damage to Player 1:
            case "thrustparry":
                turnOutcomeText = string.Format("{0} lunged with a Thrust, but {1} Parried the hit!\n\n{0} takes 1 damage!", p1Name, p2Name);
                break;

            //Text for 2 Damage to Player 2:
            case "parrystrike":
                turnOutcomeText = string.Format("{1} aimed to Strike {0}, but {0} Parried the hit!\n\n{1} takes 2 damage!", p1Name, p2Name);
                break;
            case "strikethrust":
                turnOutcomeText = string.Format("{1} lunged with a Thrust, but {0} disarmed them with a Strike!\n\n{1} takes 2 damage!", p1Name, p2Name);
                break;
            case "thrustblock":
                turnOutcomeText = string.Format("{1} prepared to Block the hit, but {0} pierced through their defence with a Thrust!\n\n{1} takes 2 damage!", p1Name, p2Name);
                break;

            //Text for 2 Damage to Player 1:
            case "strikeparry":
                turnOutcomeText = string.Format("{0} aimed to Strike {1}, but {1} Parried the hit!\n\n{0} takes 2 damage!", p1Name, p2Name);
                break;
            case "thruststrike":
                turnOutcomeText = string.Format("{0} lunged with a Thrust, but {1} disarmed them with a Strike!\n\n{0} takes 2 damage!", p1Name, p2Name);
                break;
            case "blockthrust":
                turnOutcomeText = string.Format("{0} prepared to Block the hit, but {1} pierced through their defence with a Thrust!\n\n{0} takes 2 damage!", p1Name, p2Name);
                break;
        }
        return turnOutcomeText;
    }

    public static string WinnerJudgement(string p1Name, string p1Action, string p2Name, string p2Action, bool playerWins)
    {
        if (playerWins)
        {
            return string.Format("With {0}'s final {1} against {2}'s {3}, {2} is defeated!\n\n{0} WINS!!", p1Name, p1Action, p2Name, p2Action);
        }
        else
        {
            return string.Format("With {2}'s final {3} against {0}'s {1}, {2} rises victorious!\n\n{0} LOSES!!", p1Name, p1Action, p2Name, p2Action);
        }
    }

    public static string DrawJudgement(string p1Name, string p2Name)
    {
        return string.Format("Both {0} and {1} knock themselves out!\n\nDRAW!!", p1Name, p2Name);
    }
}
