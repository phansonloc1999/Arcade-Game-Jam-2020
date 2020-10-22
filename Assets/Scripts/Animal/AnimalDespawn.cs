using UnityEngine;

public class AnimalDespawn : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Animal" || other.tag == "Tree")
        {
            Destroy(other.gameObject);
        }
    }
}