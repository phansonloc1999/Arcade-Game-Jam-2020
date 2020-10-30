using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] private List<GameObject> _animalsToBeBombed;

    [SerializeField] private Text _bombText;

    [SerializeField] private int _maxBomb;

    [SerializeField] private int _bombLeft;

    [SerializeField] private GameObject[] _bombImages;

    // Start is called before the first frame update
    void Start()
    {
        _animalsToBeBombed = new List<GameObject>();

        _bombLeft = _maxBomb;
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

        _bombLeft = Mathf.Max(_bombLeft - 1, 0);

        _bombText.text = "Bomb " + _bombLeft;

        for (int i = 0; i < _bombLeft; i++)
        {
            _bombImages[i].SetActive(true);
        }

        for (int i = _bombLeft; i < _maxBomb; i++)
        {
            _bombImages[i].SetActive(false);
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
