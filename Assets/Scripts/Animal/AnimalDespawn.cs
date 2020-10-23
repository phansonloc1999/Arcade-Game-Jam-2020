using UnityEngine;

public class AnimalDespawn : MonoBehaviour
{
    private static Bomb _bomb;

    private void Start()
    {
        if (_bomb == null)
        {
            _bomb = GameObject.Find("Capsule Gun").GetComponent<Bomb>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Animal" || other.tag == "Tree")
        {
            Destroy(other.gameObject);
        }
    }
}