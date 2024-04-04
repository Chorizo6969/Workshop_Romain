using UnityEngine;
using Cinemachine;
using System.Collections;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _swordEmpty;
    [SerializeField]
    private Animation _fondu;
    [SerializeField]
    private Animation _sword;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            _sword.Play();
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        _fondu.Play();
        yield return new WaitForSeconds(2);
        _spriteRenderer.sprite = _swordEmpty;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
