using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public void ReturnMainScene()
    {
        SceneManager.LoadScene("SampleScene");  // ��Ȯ�� ���ξ� �̸�!
    }
}
