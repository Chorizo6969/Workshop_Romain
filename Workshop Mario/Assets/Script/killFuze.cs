using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killFuze : MonoBehaviour
{
    [SerializeField] private GameObject fuze;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(fuze, 1);
    }
}
