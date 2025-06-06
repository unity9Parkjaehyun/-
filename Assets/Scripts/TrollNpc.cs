using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TrollNPC : MonoBehaviour
{
    public GameObject dialogueUI;          // 源燃識 鳶確
    public TextMeshProUGUI dialogueText;   // 源燃識拭 妊獣吃 努什闘
    public Button nextButton;              // 陥製 企紫 獄動

    private int dialogueIndex = 0;         // 薄仙 企紫 昔畿什

    // 企紫 鯉系
    private string[] dialogues = {
        "訊 戚係惟 亨 含虞細嬢辞\n" +
            "E 研 喚君企澗意亜 ?",
        "更? 鎧亜 神虞梅陥壱 ? ",
        "紫叔 神虞澗闇 姥虞心革",
            "獣娃涯搾 鯵蝦戚浦",
        "煽奄 図楕税 NPC 拭惟稽 亜惟.",
            " 訊 , 伸閤蟹? 鉢蟹蟹 ? ",
            " 切革亜 蟹廃砺 校 拝 呪 赤走?  ",
            " せせせせせせせせせせ ",
            " せせせせせせせせせせ\n" +
            "せせせせせせせせせせせ ",
    };

    private bool playerNear = false;       // 巴傾戚嬢亜 亜猿錘走 食採

    void Start()
    {
        // 惟績 獣拙拝 凶 湛 企紫 妊獣
        dialogueUI.SetActive(true);
        dialogueText.text = "戚坐 戚楕生稽 神惟!!\n[Press E]";
        nextButton.gameObject.SetActive(false); // 湛 企紫澗 獄動 需沿
    }

    void Update()
    {
        // 巴傾戚嬢亜 亜猿戚 赤壱, E 徹研 刊牽檎 企鉢 遭楳
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
            nextButton.gameObject.SetActive(true); // 獄動 醗失鉢
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            nextButton.gameObject.SetActive(false); // 獄動 需沿
        }
    }

    // 獄動 刊牽暗蟹 E徹 刊牽檎 硲窒鞠澗 敗呪
    public void ShowNextDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            // 原走厳 企紫 板 源燃識 塊奄
            dialogueUI.SetActive(false);
            nextButton.gameObject.SetActive(false);
        }
    }
}
