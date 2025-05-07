using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// SceneFade : ���� ������ �� �������, ���� �ٲ� �� ��ο����� ��ũ��Ʈ
public class SceneFade : MonoBehaviour
{
    public Image fadeImage;         // ȭ���� ���� �г� �̹���
    public float fadeSpeed = 1f;    // ���̵� �ӵ�

    private bool isFadingIn = true;  // �� ���� �� ������� ������ ����
    private bool isFadingOut = false; // �� ��ȯ �� ��ο����� ������ ����
    private string nextScene;        // �̵��� �� �̸�

    private void Start()
    {
        // ������ �� �г��� ������ �˰� ���� (���İ� 1)
        Color c = fadeImage.color;
        c.a = 1f;  // ������ ������
        fadeImage.color = c;

        // ���� �����ϸ� ������� ����
        isFadingIn = true;
    }

    // �� ��ȯ & ���̵� �ƿ� ���� �Լ�
    public void StartFade(string sceneName)
    {
        nextScene = sceneName;     // �̵��� �� �̸� ���
        isFadingOut = true;        // ���̵� �ƿ� ����
        isFadingIn = false;        // ���̵� ���� ����
    }

    private void Update()
    {
        // �� ���� : ������� (���̵� ��)
        if (isFadingIn)
        {
            Color c = fadeImage.color;
            c.a -= Time.deltaTime * fadeSpeed; // ���İ� ���̱� -> ��������

            if (c.a <= 0f) // ������ ���������� ��
            {
                c.a = 0f;
                isFadingIn = false; // ������� ����
            }

            fadeImage.color = c;
        }

        // �� ��ȯ : ��ο����� (���̵� �ƿ�)
        if (isFadingOut)
        {
            Color c = fadeImage.color;
            c.a += Time.deltaTime * fadeSpeed; // ���İ� ���� -> ����������

            if (c.a >= 1f) // ������ ��ο����� �� �̵�
            {
                c.a = 1f;
                SceneManager.LoadScene(nextScene);
            }

            fadeImage.color = c;
        }
    }
}