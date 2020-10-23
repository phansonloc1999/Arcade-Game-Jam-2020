using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private List<GameObject> _animalsToBeBombed;

    // Start is called before the first frame update
    void Start()
    {
        _animalsToBeBombed = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Use();
        }
    }

    void Use()
    {
        foreach (var animal in _animalsToBeBombed)
        {
            Destroy(animal);
        }
    }

    public void AddOnScreenAnimal(GameObject animal)
    {
        _animalsToBeBombed.Add(animal);
    }

    public void RemoveOnScreenAnimal(GameObject animal)
    {
        _animalsToBeBombed.Remove(animal);
    }
}
