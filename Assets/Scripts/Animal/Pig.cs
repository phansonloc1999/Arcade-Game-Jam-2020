using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [SerializeField] private float _dealDamageInterval;

    [SerializeField] private int _damageAmmount;

    [SerializeField] private bool _dealtDamage;

    private Animator _animator;

    private static float? _startDealingDamageX = null;
    private static float? _stopDealingDamageX = null;

    // Start is called before the first frame update
    void Start()
    {
        if (_startDealingDamageX == null && _stopDealingDamageX == null)
        {
            _startDealingDamageX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            _stopDealingDamageX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        }

        _animator = GetComponent<Animator>();
        _animator.SetBool("isPig", true);

        _dealtDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Constants.Instance.TopLeftScreenWorldPos.x && !_dealtDamage)
        {
            _dealtDamage = true;

            PlayerHealth.TakeDamage(_damageAmmount);
        }
    }
}
