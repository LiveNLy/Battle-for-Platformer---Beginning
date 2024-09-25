using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Fliper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed;
    [SerializeField] private FieldOfView _fieldOfView;

    private Fliper _fliper;
    private int _numberOfMovePoint = 0;
    private bool _flipped = true;
    private Coroutine _patroling;
    private float _timeForCoroutine = 0.001f;

    private void Awake()
    {
        _fliper = GetComponent<Fliper>();

        StartCoroutinePatroling();
    }

    private void OnEnable()
    {
        _fieldOfView.CharacterFound += StartCoroutineFollowing;
        _fieldOfView.CharacterLost += StartCoroutinePatroling;
    }

    private void Update()
    {
        Flip();
    }

    private void OnDisable()
    {
        _fieldOfView.CharacterFound -= StartCoroutineFollowing;
        _fieldOfView.CharacterLost -= StartCoroutinePatroling;
    }

    public void StartCoroutinePatroling()
    {
        if (_patroling != null)
            StopCoroutine(_patroling);

        _patroling = StartCoroutine(Patroling());
    }

    private void StartCoroutineFollowing(Vector2 characterPosition)
    {
        if (_patroling != null)
            StopCoroutine(_patroling);

        _patroling = StartCoroutine(FollowTheCharacter(characterPosition));
    }

    private IEnumerator FollowTheCharacter(Vector2 characterPosition)
    {
        var time = new WaitForSeconds(_timeForCoroutine);

        while (enabled)
        {
            transform.position = Vector2.MoveTowards(transform.position, characterPosition, _speed * Time.deltaTime);

            yield return time;
        }
    }

    private IEnumerator Patroling()
    {
        var time = new WaitForSeconds(_timeForCoroutine);

        while (enabled)
        {
            transform.position = Vector2.MoveTowards(transform.position, _movePoints[_numberOfMovePoint].position, _speed * Time.deltaTime);

            if (transform.position == _movePoints[_numberOfMovePoint].position)
                _numberOfMovePoint = (++_numberOfMovePoint) % _movePoints.Length;

            yield return time;
        }
    }

    private void Flip()
    {
        if (_numberOfMovePoint == 0 && !_flipped || _numberOfMovePoint == 1 && _flipped)
        {
            _fliper.Flip();
            _flipped = !_flipped;
        }
    }
}