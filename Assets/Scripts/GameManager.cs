using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Gladiator g_Player1, g_Player2;
    private bool isGameActive = true;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI namePlatePlayer;
    public TextMeshProUGUI namePlateCPU;
    public TextMeshProUGUI turnOutcomeText;
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI foeHPText;
    public GameObject turnOutcomeBox;
    public GameObject actionBox;
    public GameObject endOfGameBox;

    public Gladiator Player1
    { get { return g_Player1; } }

    public Gladiator Player2
    { get { return g_Player2; } }

    private void CreatePlayerGladiator()
    {
        if (PersistenceManager.PersistenceInstance != null)
        {
            g_Player1 = new Gladiator(PersistenceManager.PersistenceInstance.PlayerName);
        }
        else
        {
            g_Player1 = new Gladiator("Bravely Defaulting Gladiator");
        }
    }

    private void CreateCPUGladiator()
    {
        g_Player2 = new GladiatorCPU();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreatePlayerGladiator();
        CreateCPUGladiator();
        dialogText.SetText(StaticDialog.CPUStrategyAIText(((GladiatorCPU)g_Player2).Shift.StrategyType));
        namePlatePlayer.SetText(g_Player1.GladName);
        namePlateCPU.SetText(g_Player2.GladName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void JudgeBatttle(string p1Action)
    {
        string p2Action = ((GladiatorCPU)g_Player2).CPUChooseAction();
        string actionKey = p1Action + p2Action;
        CompareAttacks(actionKey);
        UpdateHPUI();
        ReviewBattleAftermath(p1Action, p2Action);
        if (!((GladiatorCPU)g_Player2).Shift.ParadigmShifted && isGameActive)
        {
            SettleCPUPostTurnActions(p1Action);
        }
    }

    private void CompareAttacks(string actionKey)
    {
        switch (actionKey)
        {
            case "strikeblock":
            case "parryparry":
            case "parryblock":
            case "blockstrike":
            case "blockparry":
            case "blockblock":
                //No Damage
                DealDamage(0, 0);
                break;
            case "strikestrike":
            case "thrustthrust":
                //1 Damage to Both
                DealDamage(1, 1);
                break;
            case "parrythrust":
                //1 Damage to P2
                DealDamage(0, 1);
                break;
            case "thrustparry":
                //1 Damage to P1
                DealDamage(1, 0);
                break;
            case "parrystrike":
            case "strikethrust":
            case "thrustblock":
                //2 Damage to P2
                DealDamage(0, 2);
                break;
            case "strikeparry":
            case "thruststrike":
            case "blockthrust":
                //2 Damage to P1
                DealDamage(2, 0);
                break;
        }
    }

    private void DealDamage(int p1Damage, int p2Damage)
    {
        g_Player1.ReceiveDamage(p1Damage);
        g_Player2.ReceiveDamage(p2Damage);
    }

    private void ReviewBattleAftermath(string p1Action, string p2Action)
    {
        if (g_Player1.HP > 0 && g_Player2.HP > 0)
        {
            //Both gladiators are still alive.
            string actionKey = p1Action + p2Action;
            turnOutcomeText.SetText(StaticDialog.TurnOutcomeText(actionKey, g_Player1.GladName, g_Player2.GladName));
            StartCoroutine(DisplayTurnOutcome());
        }
        else
        {
            //End game and decide winner.
            isGameActive = false;
            if (g_Player1.HP == 0 && g_Player2.HP > 0)
            {
                //Player Loses.
                turnOutcomeText.SetText(StaticDialog.WinnerJudgement(g_Player1.GladName, p1Action, g_Player2.GladName, p2Action, false));
            }
            else if (g_Player1.HP > 0 && g_Player2.HP == 0)
            {
                //Player Wins.
                turnOutcomeText.SetText(StaticDialog.WinnerJudgement(g_Player1.GladName, p1Action, g_Player2.GladName, p2Action, true));
            }
            else
            {
                //Draw.
                turnOutcomeText.SetText(StaticDialog.DrawJudgement(g_Player1.GladName, g_Player2.GladName));
            }
            turnOutcomeBox.SetActive(true);
            endOfGameBox.SetActive(true);
            actionBox.SetActive(false);
        }
    }

    IEnumerator DisplayTurnOutcome()
    {
        turnOutcomeBox.SetActive(true);
        actionBox.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        turnOutcomeBox.SetActive(false);
        actionBox.SetActive(true);
    }

    private void SettleCPUPostTurnActions(string p1Action)
    {
        ((GladiatorCPU)g_Player2).Shift.RememberPlayersMove(p1Action);
        ((GladiatorCPU)g_Player2).SetCombatAI(((GladiatorCPU)g_Player2).Shift.Analyze());
        if (((GladiatorCPU)g_Player2).Shift.ParadigmShifted)
        {
            dialogText.SetText(StaticDialog.CPUCombatAIShiftText(((GladiatorCPU)g_Player2).Paradigm.CombatType, g_Player2.GladName));
        }
    }

    private void UpdateHPUI()
    {
        playerHPText.SetText(string.Format("HP: {0} / 10", g_Player1.HP));
        foeHPText.SetText(string.Format("HP: {0} / 10", g_Player2.HP));
    }

    public void StrikePressed()
    {
        JudgeBatttle("strike");
    }

    public void ThrustPressed()
    {
        JudgeBatttle("thrust");
    }

    public void ParryPressed()
    {
        JudgeBatttle("parry");
    }

    public void BlockPressed()
    {
        JudgeBatttle("block");
    }

    public void NewGamePressed()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToLobbyPressed()
    {
        SceneManager.LoadScene(0);
    }
}
