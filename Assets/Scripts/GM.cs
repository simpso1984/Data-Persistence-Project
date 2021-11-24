using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static GM Instance;

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

    }

    public void LoadGame()
    {

    }
}
