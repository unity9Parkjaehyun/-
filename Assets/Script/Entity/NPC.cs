using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI; // 말풍선 (패널)
    private bool isPlayerNear = false; // 플레이어가 가까이 있는지 여부

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true); // 말풍선 켜기
            isPlayerNear = true; // 플레이어 접근 중
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueUI != null)

            {
                dialogueUI.SetActive(false);
            }
        }
    }

    private void Update()
    {
        // 플레이어가 가까이 있고 말풍선이 켜져 있을 때만 키 입력 받기
        if (isPlayerNear && dialogueUI.activeSelf)
        {
            // Y 키 → 미니게임 씬으로 이동
            if (Input.GetKeyDown(KeyCode.Y))
            {
                FindObjectOfType<SceneFade>().StartFade("Minigame1");
            }
            // N 키 → 말풍선 끄기
            else if (Input.GetKeyDown(KeyCode.N))
            {
                dialogueUI.SetActive(false);
            }
        }
    }
}

