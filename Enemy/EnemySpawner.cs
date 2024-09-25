using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    private int _enemyNumber = 0;
    private float _respawnTimer = 4f;

    private void Start()
    {
        StartCoroutine(DeathCoundown());
    }

    private IEnumerator DeathCoundown()
    {
        var countdown = new WaitForSeconds(_respawnTimer);

        while (enabled)
        {
            _enemies[_enemyNumber].gameObject.SetActive(true);
            _enemies[_enemyNumber].MoveOnActive();
            _enemyNumber = (++_enemyNumber) % _enemies.Length;

            yield return countdown;
        }
    }
}
