using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploseBombe : MonoBehaviour
{
    [SerializeField] private string tagCible;
    [SerializeField] private GameObject KABOOM;
    [SerializeField] private List<GameObject> KABOOMListSong;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagCible))
        {
            Destroy(other.gameObject.GetComponent<Ennemy>());
            Destroy(other.GetComponent<BoxCollider2D>());
            Destroy(other.GetComponent<Rigidbody2D>());
            other.GetComponent<Animator>().Play("explode");
            GameObject newKaboom = Instantiate(KABOOM);
            newKaboom.transform.position = other.transform.position;
            int randomIndex = Random.Range(0, KABOOMListSong.Count);
            KABOOMListSong[randomIndex].GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 0.31f);
        }
    }
}