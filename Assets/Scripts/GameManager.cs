using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    private Gladiator g_Player1, g_Player2;

    public Gladiator Player1
    { get { return g_Player1; } }

    public Gladiator Player2
    { get { return g_Player2; } }

    public void CreatePlayerGladiator()
    {
        g_Player1 = new Gladiator(PersistenceManager.PersistenceInstance.PlayerName);
    }

    public void CreateCPUGladiator()
    {
        g_Player2 = new GladiatorCPU();
    }

    public void JudgeBatttle(string p1Action)
    {
        string p2Action = ((GladiatorCPU)g_Player2).CPUChooseAction();
        Debug.Log("Player 1 Attack: " + p1Action + "; Player 2 HP: " + p2Action);
        string actionkey = p1Action + p2Action;
        switch (actionkey)
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
            case "strikethrust":
            case "thrustblock":
            case "parrystrike":
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
        ((GladiatorCPU)g_Player2).SetCombatAI(((GladiatorCPU)g_Player2).Shift.Analyze());
    }

    public void DealDamage(int p1Damage, int p2Damage)
    {
        g_Player1.ReceiveDamage(p1Damage);
        g_Player2.ReceiveDamage(p2Damage);
        Debug.Log("Player 1 HP: " + g_Player1.HP + "; Player 2 HP: " + g_Player2.HP);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreatePlayerGladiator();
        CreateCPUGladiator();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
