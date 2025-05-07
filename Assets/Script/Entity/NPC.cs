using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI; // ��ǳ�� (�г�)
    private bool isPlayerNear = false; // �÷��̾ ������ �ִ��� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueUI.SetActive(true); // ��ǳ�� �ѱ�
            isPlayerNear = true; // �÷��̾� ���� ��
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
        // �÷��̾ ������ �ְ� ��ǳ���� ���� ���� ���� Ű �Է� �ޱ�
        if (isPlayerNear && dialogueUI.activeSelf)
        {
            // Y Ű �� �̴ϰ��� ������ �̵�
            if (Input.GetKeyDown(KeyCode.Y))
            {
                FindObjectOfType<SceneFade>().StartFade("Minigame1");
            }
            // N Ű �� ��ǳ�� ����
            else if (Input.GetKeyDown(KeyCode.N))
            {
                dialogueUI.SetActive(false);
            }
        }
    }
}

