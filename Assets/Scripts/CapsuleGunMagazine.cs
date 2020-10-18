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
        if (!_isReloading)
        {
            if (_ammoLeft <= 0)
            {
                StartCoroutine(ReloadFull());
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    StartCoroutine(ReloadOne());
                }
            }
        }
    }

    public void DecreaseAmmo()
    {
        AmmoLeft--;
    }

    private IEnumerator ReloadFull()
    {
        _isReloading = true;

        for (int i = 0; i < _maxAmmo; i++)
        {
            yield return new WaitForSeconds(_reloadOneBulletDuration);

            _ammoLeft++;
        }

        _isReloading = false;

        yield break;
    }

    private IEnumerator ReloadOne()
    {
        _isReloading = true;

        yield return new WaitForSeconds(_reloadOneBulletDuration);

        _ammoLeft = Mathf.Min(_maxAmmo, _ammoLeft + 1);

        _isReloading = false;

        yield break;
    }
}
