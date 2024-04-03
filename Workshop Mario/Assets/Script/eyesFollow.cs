using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesFollow : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = FindAnyObjectByType<Move>().gameObject;
    }

    private void Update()
    {
        Vector3 directon = transform.position + player.transform.position;


    }
}
