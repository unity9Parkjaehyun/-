using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrollNPC : MonoBehaviour
{
    public GameObject dialogueUI;          // 말풍선 패널
    public TextMeshProUGUI dialogueText;   // 말풍선에 표시될 텍스트
    public Button nextButton;              // 다음 대사 버튼

    private int dialogueIndex = 0;         // 현재 대사 인덱스

    // 대사 목록
    private string[] dialogues = {
        "왜 이렇게 딱 달라붙어서\n" +
            "E 를 눌러대는겐가 ?",
        "뭐? 내가 오라했다고 ? ",
        "사실 오라는건 구라였네",
            "시간낭비 개꿀이군",
        "저기 왼쪽의 NPC 에게로 가게.",
            " 왜 , 열받나? 화나나 ? ",
            " 자네가 나한테 뭘 할 수 있지?  ",
            " ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ ",
            " ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ\n" +
            "ㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋㅋ ",
    };

    private bool playerNear = false;       // 플레이어가 가까운지 여부

    void Start()
    {
        // 게임 시작할 때 첫 대사 표시
        dialogueUI.SetActive(true);
        dialogueText.text = "이봐 이쪽으로 오게!!\n[Press E]";
        nextButton.gameObject.SetActive(false); // 첫 대사는 버튼 숨김
    }

    void Update()
    {
        // 플레이어가 가까이 있고, E 키를 누르면 대화 진행
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
            nextButton.gameObject.SetActive(true); // 버튼 활성화
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            nextButton.gameObject.SetActive(false); // 버튼 숨김
        }
    }

    // 버튼 누르거나 E키 누르면 호출되는 함수
    public void ShowNextDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            // 마지막 대사 후 말풍선 끄기
            dialogueUI.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }
}
