using UnityEngine;
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
    private Animator _animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            //_animator.SetBool("IsSword", true);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        _fondu.Play();
        yield return new WaitForSeconds(2);
       // _animator.SetBool("IsSword", false);
        _spriteRenderer.sprite = _swordEmpty;
        GetComponent<BoxCollider2D>().enabled = false;
    }


}
