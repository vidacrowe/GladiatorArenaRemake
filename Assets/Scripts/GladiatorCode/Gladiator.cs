using UnityEngine;

public class Gladiator
{
    protected int g_HP;
    protected string g_GladName;

    public int HP
    { get { return g_HP; } protected set { g_HP = value; } }

    public string GladName
    { get { return g_GladName; } protected set { g_GladName = value; } }

    public Gladiator()
    { 
    }

    public Gladiator(string gladName)
    {
        this.HP = 10;
        this.GladName = gladName;
    }

    public void ReceiveDamage(int damageTaken)
    {
        g_HP -= damageTaken;
    }
}
