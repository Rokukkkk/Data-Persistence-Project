using UnityEngine;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    private TextMeshProUGUI bestScoreText;

    public static MenuManager Instance;

    public string PlayerName;
    public string SavedPlayerName;
    public int SavedPoint;

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

    void Start()
    {
        bestScoreText = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
        LoadPoint();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int Point;
    }

    public void SavePoint()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.Point = SavedPoint;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadPoint()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            SavedPlayerName = data.PlayerName;
            SavedPoint = data.Point;
        }
        else
        {
            bestScoreText.text = "Best Score: No Record Found";
        }
    }
}
