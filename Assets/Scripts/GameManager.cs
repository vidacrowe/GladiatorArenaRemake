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
}
