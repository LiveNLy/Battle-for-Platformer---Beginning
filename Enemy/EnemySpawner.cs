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
            _enemyNumber++;

            if (_enemyNumber >= _enemies.Length)
                _enemyNumber = 0;

            yield return countdown;
        }
    }
}
