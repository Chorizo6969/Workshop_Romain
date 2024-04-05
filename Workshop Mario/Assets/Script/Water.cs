using System.Collections;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    private GameObject self;

    private void Start()
    {
        StartCoroutine(moveWater());
    }

    IEnumerator moveWater()
    {
        while (true)
        {
            self.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            self.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
