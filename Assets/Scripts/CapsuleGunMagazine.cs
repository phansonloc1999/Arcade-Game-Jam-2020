using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGunMagazine : MonoBehaviour
{
    [SerializeField] private int _maxAmmo;

    [SerializeField] private int _ammoLeft;

    public int AmmoLeft { get => _ammoLeft; set => _ammoLeft = value; }

    // Start is called before the first frame update
    void Start()
    {
        AmmoLeft = _maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseAmmo()
    {
        AmmoLeft--;
    }
}
