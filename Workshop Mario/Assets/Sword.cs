using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite _swordEmpty;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            _spriteRenderer.sprite = _swordEmpty;
        }
    }
}
