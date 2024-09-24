using System;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public event Action<Vector2> CharacterFound;
    public event Action CharacterLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            CharacterFound?.Invoke(character.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            CharacterLost?.Invoke();
        }
    }
}
