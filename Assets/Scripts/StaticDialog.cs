using UnityEngine;

static class StaticDialog
{
    public static string CPUCombatAIText(int combatType)
    {
        string combatTypeText = string.Empty;
        switch (combatType)
        {
            case 1:
                combatTypeText = "";
                break;
            case 2:
                combatTypeText = "";
                break;
            case 3:
                combatTypeText = "";
                break;
            case 4:
                combatTypeText = "";
                break;
        }
        return combatTypeText;
    }

    public static string CPUStrategyAIText(int strategyType)
    {
        string strategyTypeText = string.Empty;
        switch (strategyType)
        {
            case 1:
                strategyTypeText = "";
                break;
            case 2:
                strategyTypeText = "";
                break;
            case 3:
                strategyTypeText = "";
                break;
            case 4:
                strategyTypeText = "";
                break;
        }
        return strategyTypeText;
    }
}
