using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalShot : MonoBehaviour
{
    [SerializeField] private ObjectMovement _objectMovement;

    private static Bomb _bomb;

    private static CapsuleGunMagazine _capsuleGunMagScript;

    // Start is called before the first frame update
    void Start()
    {
        if (_capsuleGunMagScript == null)
        {
            _capsuleGunMagScript = GameObject.Find("Capsule Gun").GetComponent<CapsuleGunMagazine>();
            _bomb = GameObject.Find("Capsule Gun").GetComponent<Bomb>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (_capsuleGunMagScript.AmmoLeft > 0)
        {
            Destroy(gameObject);

            _capsuleGunMagScript.DecreaseAmmo();
        }
    }

    private void OnDestroy()
    {
        _bomb.RemoveOnScreenAnimal(gameObject);
    }
}
