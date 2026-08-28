using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private bool gameCompleted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void CompleteGame()
    {
        if (gameCompleted)
            return;

        gameCompleted = true;

        Debug.Log("MISSION COMPLETE!");
    }

    public bool IsGameCompleted()
    {
        return gameCompleted;
    }
}