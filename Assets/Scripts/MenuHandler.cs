using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreField;
    public TMP_InputField nameInputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadHighScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
    #else
            Application.Quit(); // original code to quit Unity player
    #endif
    }

    public void LoadHighScore() {
        DataManager.Instance.LoadHighScore();
        if (DataManager.Instance.highScore == 0) {
            bestScoreField.text = "High Score : No Data";
            return;
        }
        bestScoreField.text = $"High Score : {DataManager.Instance.highScorePlayerName} : {DataManager.Instance.highScore}";
    }
}
