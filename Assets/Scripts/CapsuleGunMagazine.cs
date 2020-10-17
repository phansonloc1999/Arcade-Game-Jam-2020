using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGunMagazine : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;

    [SerializeField] private int _ammoLeft;

    public int AmmoLeft { get => _ammoLeft; set => _ammoLeft = value; }

    [SerializeField] private float _reloadOneBulletDuration;

    private bool _isReloading;

    // Start is called before the first frame update
    void Start()
    {
        AmmoLeft = _maxAmmo;

        _isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_ammoLeft <= 0 && !_isReloading)
        {
            StartCoroutine(ReloadAll());
        }
    }

    public void DecreaseAmmo()
    {
        AmmoLeft--;
    }

    private IEnumerator ReloadAll()
    {
        _isReloading = true;

        for (int i = 0; i < _maxAmmo; i++)
        {
            yield return new WaitForSeconds(_reloadOneBulletDuration);

            _ammoLeft++;
        }

        yield break;
    }
}
