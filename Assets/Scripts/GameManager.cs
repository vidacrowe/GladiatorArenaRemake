using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    private Gladiator gPlayer1, gPlayer2;

    public Gladiator Player1
    { get { return gPlayer1; } }

    public Gladiator Player2
    { get { return gPlayer2; } }

    public void CreatePlayerGladiator()
    {
        gPlayer1 = new Gladiator(PersistenceManager.PersistenceInstance.PlayerName);
    }

    public void CreateCPUGladiator()
    {
        gPlayer2 = new GladiatorCPU();
    }

    public void JudgeBatttle(string p1Action)
    {
        string p2Action = ((GladiatorCPU)gPlayer2).CPUChooseAction();
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
                break;
            case "strikestrike":
            case "thrustthrust":
                //1 Damage to Both
                break;
            case "parrythrust":
                //1 Damage to P2
                break;
            case "thrustparry":
                //1 Damage to P1
                break;
            case "strikethrust":
            case "thrustblock":
            case "parrystrike":
                //2 Damage to P2
                break;
            case "strikeparry":
            case "thruststrike":
            case "blockthrust":
                //2 Damage to P1
                break;
        }
        ((GladiatorCPU)gPlayer2).SetCombatAI(((GladiatorCPU)gPlayer2).Shift.Analyze());
    }

    public void DealDamage(int p1Damage, int p2Damage)
    {
        gPlayer1.ReceiveDamage(p1Damage);
        gPlayer2.ReceiveDamage(p2Damage);
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
