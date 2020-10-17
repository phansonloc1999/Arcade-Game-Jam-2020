using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalShot : MonoBehaviour
{
    private static CapsuleGunMagazine _capsuleGunMagScript;

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
            var animalMovement = GetComponent<ObjectMovement>();

            animalMovement?.MoveTween.Kill();

            Destroy(gameObject);

            _capsuleGunMagScript.DecreaseAmmo();
        }
    }
}
