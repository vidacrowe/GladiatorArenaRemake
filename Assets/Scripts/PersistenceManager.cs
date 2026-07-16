using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager PersistenceInstance { get; private set; }
    private string playerName;

    public string PlayerName
    { get { return playerName; } }

    private void Awake()
    {
        //Singleton - Ensure only one instance of PersistenceManager exists.
        if (PersistenceInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        //Create instance of PersistenceManager.
        PersistenceInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName(string textName)
    {
        playerName = textName;
    }

    //Quick logging utility. To delete later.
    public void QuickLog()
    {
        //Debug.Log("Player Name: " + activePlayerName + "; Final Score: " + activePlayerScore);
        Debug.Log("Player Name: " + playerName);
        //Debug.Log(Application.persistentDataPath);
    }
}
