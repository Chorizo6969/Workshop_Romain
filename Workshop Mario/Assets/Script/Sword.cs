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
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private AudioSource _sword;
    private int speed = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            _animator.SetBool("IsSword", true);
            _player.GetComponent<Move>().enabled = false;
            speed = 2;
            _player.transform.position = new Vector3(60, -2.36f, 0);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        _fondu.Play();
        yield return new WaitForSeconds(3.5f);
        _sword.Play();
        yield return new WaitForSeconds(1.5f);
        _animator.SetBool("IsSword", false);
        _spriteRenderer.sprite = _swordEmpty;
        GetComponent<BoxCollider2D>().enabled = false;
        _player.GetComponent<Move>().enabled = true;
    }

    private void FixedUpdate()
    {
        _player.transform.Translate(new Vector3(0.6f, 0, 0) * speed *Time.deltaTime);
        if (speed == 2)
        {
            StartCoroutine(Delay2());
        }
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(1.5f);
        speed = 0;
    }
}
