using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;     // 현재 점수 표시 텍스트
    public TextMeshProUGUI highScoreText;        // 최고 점수 표시 텍스트
    public TextMeshProUGUI restartText;          // 게임 오버 텍스트
    public GameObject goToMainButton;

    private int currentScore = 0; // ⭐ 현재 점수 저장 변수

    void Start()
    {
        if (restartText == null)
            Debug.LogError("restart text is null");
        if (currentScoreText == null)
            Debug.LogError("currentScoreText is null");
        if (highScoreText == null)
            Debug.LogError("highScoreText is null");

        restartText.gameObject.SetActive(false);
        if (goToMainButton != null)
            goToMainButton.SetActive(false);
        highScoreText.gameObject.SetActive(false);

        // 최고 점수 불러오기
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "최고 점수 : " + highScore;
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "최고 점수 :" + highScore;
        highScoreText.gameObject.SetActive(true);
    }

    // ⭐ 점수 업데이트 (숫자 받아서 현재점수와 최고점수 갱신)
    public void UpdateScore(int score)
    {
        currentScore = score;
        currentScoreText.text = "현재 점수 : " + currentScore;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScoreText.text = "최고 점수 : " + currentScore;
        }
    }

    public void SetGoToMainButton()
    {
        if (goToMainButton != null)
            goToMainButton.SetActive(true);
    }
}


