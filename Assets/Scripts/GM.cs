using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GM : MonoBehaviour
{

    public static GM Instance;
    public int highScore;
    public string highScoreName;
    public string playerName;
    public InputField inputPlayerName;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
        print("LOADED");

    }

    public void StartGame()
    {
        playerName = inputPlayerName.text;
  
        if (playerName != "")
        {
            print(playerName);
            SceneManager.LoadScene(1);
        }

    }

    //SAVE AND LOAD

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        print("save complete");
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;


            print(highScoreName + " " + highScore);
        }

    }
}
