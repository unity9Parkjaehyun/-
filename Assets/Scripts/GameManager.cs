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
        uiManager.UpdateScore(0); // ���� �� ���� 0���� UIManager�� ����
    }

    public void gameover()
    {
        followCamera.GameOver();
        uiManager.SetRestart();
        uiManager.SetGoToMainButton(); // �� �κ� FindObjectOfType �� �ʿ� ��������
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        // ���� UIManager�� ���� �� UIManager�� ���� ������ �ְ� ���� ����
        uiManager.UpdateScore(score);
        Debug.Log("Score Added: " + score);
    }
}
