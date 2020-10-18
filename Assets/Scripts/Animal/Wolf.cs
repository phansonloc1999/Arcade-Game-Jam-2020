using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] private float _dealDamageInterval;

    [SerializeField] private int _damageAmmount;

    [SerializeField] private bool _startDealingDamage;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _startDealingDamageX && transform.position.x > _stopDealingDamageX && !_startDealingDamage)
        {
            _startDealingDamage = true;
            StartCoroutine(DealDamageToPlayer());
        }
    }

    IEnumerator DealDamageToPlayer()
    {
        while (_startDealingDamage)
        {
            yield return new WaitForSeconds(_dealDamageInterval);

            PlayerHealth.TakeDamage(_damageAmmount);
        }

        yield break;
    }
}
