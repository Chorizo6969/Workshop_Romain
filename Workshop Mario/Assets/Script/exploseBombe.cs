using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploseBombe : MonoBehaviour
{
    [SerializeField] private string tagCible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagCible))
        {
            Destroy(other.gameObject.GetComponent<Ennemy>());
            Destroy(other.GetComponent<BoxCollider2D>());
            Destroy(other.GetComponent<Rigidbody2D>());
            other.GetComponent<Animator>().Play("explode");
            Destroy(other.gameObject, 0.31f);
        }
    }
}