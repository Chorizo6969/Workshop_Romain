using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject PANEL;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PANEL.SetActive(true);
    }

    public void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
