using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;

    public void MoveOnActive()
    {
        _enemyMover.StartCoroutinePatroling();
    }
}
