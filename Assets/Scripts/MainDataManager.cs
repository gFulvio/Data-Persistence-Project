using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainDataManager : MonoBehaviour
{
    public static MainDataManager Instance;
    public string input;
    public new string name;
    public TextMeshProUGUI bestScoreText;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = name;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            name = data.name;
            bestScore = data.bestScore;
        }
    }
}
