using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimalShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        var animalMovement = GetComponent<ObjectMovement>();

        animalMovement?.MoveTween.Kill();

        Destroy(gameObject);
    }
}
