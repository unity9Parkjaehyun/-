using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrollNPC : MonoBehaviour
{
    public GameObject dialogueUI;          // ��ǳ�� �г�
    public TextMeshProUGUI dialogueText;   // ��ǳ���� ǥ�õ� �ؽ�Ʈ
    public Button nextButton;              // ���� ��� ��ư

    private int dialogueIndex = 0;         // ���� ��� �ε���

    // ��� ���
    private string[] dialogues = {
        "�� �̷��� �� �޶�پ\n" +
            "E �� ������°հ� ?",
        "��? ���� �����ߴٰ� ? ",
        "��� ����°� ���󿴳�",
            "�ð����� �����̱�",
        "���� ������ NPC ���Է� ����.",
            " �� , ���޳�? ȭ���� ? ",
            " �ڳװ� ������ �� �� �� ����?  ",
            " �������������������� ",
            " ��������������������\n" +
            "���������������������� ",
    };

    private bool playerNear = false;       // �÷��̾ ������� ����

    void Start()
    {
        // ���� ������ �� ù ��� ǥ��
        dialogueUI.SetActive(true);
        dialogueText.text = "�̺� �������� ����!!\n[Press E]";
        nextButton.gameObject.SetActive(false); // ù ���� ��ư ����
    }

    void Update()
    {
        // �÷��̾ ������ �ְ�, E Ű�� ������ ��ȭ ����
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            nextButton.gameObject.SetActive(true); // ��ư Ȱ��ȭ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            nextButton.gameObject.SetActive(false); // ��ư ����
        }
    }

    // ��ư �����ų� EŰ ������ ȣ��Ǵ� �Լ�
    public void ShowNextDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            // ������ ��� �� ��ǳ�� ����
            dialogueUI.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }
}
