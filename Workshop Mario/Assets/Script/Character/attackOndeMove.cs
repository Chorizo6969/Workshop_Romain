using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class attackOndeMove : MonoBehaviour
{
    [SerializeField] private float delai = 0.5f;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.SetActive(true);
        StartCoroutine(Attend());
    }

    IEnumerator Attend()
    {
        yield return new WaitForSeconds(delai);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PORTE"))
        {
            collision.gameObject.GetComponent<Animator>().Play("doorDisappear");
            Destroy(collision.gameObject.GetComponent<TilemapCollider2D>());
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Destroy(collision.gameObject.GetComponent<CompositeCollider2D>());
            Destroy(collision.gameObject, 1);
        }
    }
}
