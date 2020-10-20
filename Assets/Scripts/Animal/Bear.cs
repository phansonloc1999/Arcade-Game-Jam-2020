using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bear : MonoBehaviour
{
    [SerializeField] private Transform _treeTransform;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private static float? _middleScreenX = null;

    [SerializeField] private bool _startRevealing;


    // Start is called before the first frame update
    void Start()
    {
        _treeTransform = transform.parent.GetComponent<Transform>();

        if (_middleScreenX == null)
        {
            _middleScreenX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 0)).x;
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_startRevealing)
        {
            if (Mathf.Floor(_treeTransform.position.x) == Mathf.Floor(_middleScreenX.Value))
            {
                transform.DOLocalMoveX(_spriteRenderer.bounds.size.x * transform.localScale.x / transform.parent.localScale.x / 2, 1.5f);

                _startRevealing = true;
            }
        }
    }
}
