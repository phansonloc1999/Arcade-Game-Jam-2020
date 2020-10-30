using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleGunMagazine : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;

    [SerializeField] private int _ammoLeft;

    public int AmmoLeft { get => _ammoLeft; set => _ammoLeft = value; }

    [SerializeField] private float _reloadOneBulletDuration;

    [SerializeField] private GameObject[] _capsuleAmmoUIElements;

    [SerializeField] private GameObject _capsule;

    [SerializeField] private Text _capsuleAmmoLeftText;

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
        UpdateCapsuleAmmoUI();
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

        UpdateCapsuleAmmoUI();

        yield break;
    }

    private IEnumerator ReloadOne()
    {
        _isReloading = true;

        yield return new WaitForSeconds(_reloadOneBulletDuration);

        _ammoLeft = Mathf.Min(_maxAmmo, _ammoLeft + 1);

        _isReloading = false;

        UpdateCapsuleAmmoUI();

        yield break;
    }

    private void UpdateCapsuleAmmoUI()
    {
        for (int i = 0; i < _ammoLeft; i++)
        {
            _capsuleAmmoUIElements[i].SetActive(true);
        }

        for (int i = _ammoLeft; i < _maxAmmo; i++)
        {
            _capsuleAmmoUIElements[i].SetActive(false);
            // Destroy(_capsuleAmmoUIElements[i]);
        }

        _capsuleAmmoLeftText.text = "Ammo " + _ammoLeft;

        Canvas.ForceUpdateCanvases();
    }
}
