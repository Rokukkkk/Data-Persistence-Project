using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    private TextMeshProUGUI bestScoreText;

    public string PlayerName;

    void Start()
    {
        bestScoreText = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
        bestScoreText.text = "Best Score: " + MenuManager.Instance.SavedPlayerName + " - " + MenuManager.Instance.SavedPoint;
    }

    public void StartGame()
    {
        PlayerName = GameObject.Find("NameInput").GetComponent<TMP_InputField>().text;
        if (PlayerName != "")
        {
            MenuManager.Instance.PlayerName = PlayerName;
            SceneManager.LoadScene(1);
        }
        else
        {
            bestScoreText.text = "Please enter player name before start the game.";
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
