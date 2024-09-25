using UnityEngine;

public class MedKit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CollisionHandler collisionHandler))
        {
            gameObject.SetActive(false);
        }
    }
}