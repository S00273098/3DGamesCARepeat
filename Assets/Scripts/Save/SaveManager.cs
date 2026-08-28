using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(
            Application.persistentDataPath,
            "savegame.json"
        );
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        Vector3 position = playerHealth.transform.position;

        data.playerPositionX = position.x;
        data.playerPositionY = position.y;
        data.playerPositionZ = position.z;

        data.playerHealth = playerHealth.CurrentHealth;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(savePath, json);

        Debug.Log("Game saved!");
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("No save file found.");
            return;
        }

        string json = File.ReadAllText(savePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Vector3 position = new Vector3(
            data.playerPositionX,
            data.playerPositionY,
            data.playerPositionZ
        );

        playerHealth.transform.position = position;

        playerHealth.SetHealth(data.playerHealth);

        Debug.Log("Game loaded!");
    }

    private void Update()
    {
        if (Keyboard.current.f5Key.wasPressedThisFrame)
        {
            SaveGame();
        }

        if (Keyboard.current.f9Key.wasPressedThisFrame)
        {
            LoadGame();
        }
    }
}