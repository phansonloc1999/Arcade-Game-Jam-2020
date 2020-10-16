﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private float _moveAcrossScreenDuration;

    private Tweener _moveTween = null;

    public Tweener MoveTween { get => _moveTween; set => _moveTween = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (_moveAcrossScreenDuration != 0)
        {
            var topLeftScreenCorner = new Vector3(0, 0, 0);
            MoveTween = transform.DOMoveX(Camera.main.ScreenToWorldPoint(topLeftScreenCorner).x, _moveAcrossScreenDuration).SetEase(Ease.Linear).SetAutoKill(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveSpeed != 0)
        {
            transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
