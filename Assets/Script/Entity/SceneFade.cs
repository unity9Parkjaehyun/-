using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// SceneFade : 씬이 시작할 때 밝아지고, 씬을 바꿀 때 어두워지는 스크립트
public class SceneFade : MonoBehaviour
{
    public Image fadeImage;         // 화면을 덮는 패널 이미지
    public float fadeSpeed = 1f;    // 페이드 속도

    private bool isFadingIn = true;  // 씬 시작 시 밝아지는 중인지 여부
    private bool isFadingOut = false; // 씬 전환 시 어두워지는 중인지 여부
    private string nextScene;        // 이동할 씬 이름

    private void Start()
    {
        // 시작할 때 패널을 완전히 검게 설정 (알파값 1)
        Color c = fadeImage.color;
        c.a = 1f;  // 완전히 불투명
        fadeImage.color = c;

        // 씬이 시작하면 밝아지기 시작
        isFadingIn = true;
    }

    // 씬 전환 & 페이드 아웃 시작 함수
    public void StartFade(string sceneName)
    {
        nextScene = sceneName;     // 이동할 씬 이름 기억
        isFadingOut = true;        // 페이드 아웃 시작
        isFadingIn = false;        // 페이드 인은 중지
    }

    private void Update()
    {
        // 씬 시작 : 밝아지기 (페이드 인)
        if (isFadingIn)
        {
            Color c = fadeImage.color;
            c.a -= Time.deltaTime * fadeSpeed; // 알파값 줄이기 -> 투명해짐

            if (c.a <= 0f) // 완전히 투명해지면 끝
            {
                c.a = 0f;
                isFadingIn = false; // 밝아지기 종료
            }

            fadeImage.color = c;
        }

        // 씬 전환 : 어두워지기 (페이드 아웃)
        if (isFadingOut)
        {
            Color c = fadeImage.color;
            c.a += Time.deltaTime * fadeSpeed; // 알파값 증가 -> 불투명해짐

            if (c.a >= 1f) // 완전히 어두워지면 씬 이동
            {
                c.a = 1f;
                SceneManager.LoadScene(nextScene);
            }

            fadeImage.color = c;
        }
    }
}