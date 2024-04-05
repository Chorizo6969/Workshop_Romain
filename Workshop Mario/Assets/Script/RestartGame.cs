using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject PANEL;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        PANEL.SetActive(true);
    }

    public void OnClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
