using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public FollowCamera followCamera;

    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    public UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0); // 시작 시 점수 0으로 UIManager에 전달
    }

    public void gameover()
    {
        followCamera.GameOver();
        uiManager.SetRestart();
        uiManager.SetGoToMainButton(); // 이 부분 FindObjectOfType 쓸 필요 없어졌음
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        // 점수 UIManager에 전달 → UIManager가 현재 점수와 최고 점수 관리
        uiManager.UpdateScore(score);
        Debug.Log("Score Added: " + score);
    }
}
