using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private static float? _spriteWidth = null;

    private static float? _initialStartX = null;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteWidth == null && _initialStartX == null)
        {
            _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            _initialStartX = Constants.Instance.TopLeftScreenWorldPos.x + 3 * _spriteWidth - _spriteWidth / 2;
        }
    }

    void FixedUpdate()
    {
        if (transform.position.x + _spriteWidth / 2 <= Constants.Instance.TopLeftScreenWorldPos.x)
        {
            transform.position = new Vector3(_initialStartX.Value, transform.position.y, transform.position.z);
        }
    }

    public float _scrollingSpeed;

    private void Update()
    {
        _spriteRenderer.material.mainTextureOffset = new Vector2(Time.time * _scrollingSpeed, 0);
    }
}