using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalShot : MonoBehaviour
{
    private static CapsuleGunMagazine _capsuleGunMagScript;

    [SerializeField] private ObjectMovement _objectMovement;

    // Start is called before the first frame update
    void Start()
    {
        if (_capsuleGunMagScript == null)
        {
            _capsuleGunMagScript = GameObject.Find("Capsule Gun").GetComponent<CapsuleGunMagazine>();
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
}
