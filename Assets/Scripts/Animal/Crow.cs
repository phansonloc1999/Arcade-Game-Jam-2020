using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private AnimalOnScreen _animalOnScreen;

    [SerializeField] private Transform _flightMinimumPointTransform;

    [SerializeField] private int _damage;

    private bool _startedFlightRoute = false;

    private static GameObject _crowflightRoute;

    private static List<Vector3> _flightRouteQueue;

    private Sequence _moveSequence;

    // Start is called before the first frame update
    void Start()
    {
        if (_flightRouteQueue == null)
        {
            _flightRouteQueue = new List<Vector3>();

            _crowflightRoute = GameObject.Find("CrowFlightRoute");

            for (int i = 0; i < _crowflightRoute.transform.childCount; i++)
            {
                _flightRouteQueue.Add(_crowflightRoute.transform.GetChild(i).transform.position);
            }
        }

        _animator = GetComponent<Animator>();
        _animator.SetBool("isCrow", true);

        _animalOnScreen = GetComponent<AnimalOnScreen>();
        _animalOnScreen.OnCrossingOnScreenStartThreshold += DisableObjectMovement;
        _animalOnScreen.OnCrossingOnScreenStartThreshold += StartFollowingFlightRoute;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartFollowingFlightRoute()
    {
        _moveSequence = DOTween.Sequence();
        for (int i = 0; i < _flightRouteQueue.Count; i++)
        {
            if (_flightRouteQueue[i] == _flightMinimumPointTransform.position)
            {
                _moveSequence.Append(transform.DOMove(_flightRouteQueue[i], 2.0f)
                .SetEase(Ease.Linear)
                .OnComplete(() =>
                {
                    PlayerHealth.TakeDamage(_damage);
                }));
            }
            else _moveSequence.Append(transform.DOMove(_flightRouteQueue[i], 2.0f)
                .SetEase(Ease.Linear));
        }

        _moveSequence.OnComplete(() =>
        {
            GetComponent<ObjectMovement>().enabled = true;
        });
    }

    public void DisableObjectMovement()
    {
        GetComponent<ObjectMovement>().enabled = false;
    }

    private void OnDestroy()
    {
        _moveSequence.Kill();
    }
}
