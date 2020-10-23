using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalShot : MonoBehaviour
{
    [SerializeField] private ObjectMovement _objectMovement;

    [SerializeField] private Collider2D _collider;

    private static Bomb _bomb;

    private static CapsuleGunMagazine _capsuleGunMagScript;

    private static Collider2D _capsuleGunCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (_capsuleGunMagScript == null && _capsuleGunCollider == null)
        {
            var capsuleGun = GameObject.Find("Capsule Gun");
            _capsuleGunMagScript = capsuleGun.GetComponent<CapsuleGunMagazine>();
            _bomb = capsuleGun.GetComponent<Bomb>();
            _capsuleGunCollider = capsuleGun.GetComponent<Collider2D>();
        }

        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (_capsuleGunMagScript.AmmoLeft > 0)
        {
            var results = new Collider2D[1];
            if (_capsuleGunCollider.OverlapCollider(new ContactFilter2D(), results) > 0 && results[0] == _collider)
            {
                Destroy(gameObject);

                _capsuleGunMagScript.DecreaseAmmo();
            }
        }
    }

    private void OnDestroy()
    {
        _bomb.RemoveOnScreenAnimal(gameObject);
    }
}
