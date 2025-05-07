using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    public void ReturnMainScene()
    {
        SceneManager.LoadScene("SampleScene");  // 정확한 메인씬 이름!
    }
}
