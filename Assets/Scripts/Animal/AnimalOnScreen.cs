using UnityEngine;

public class AnimalOnScreen : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private static GameObject _onScreenStartThreshold;
    private static GameObject _onScreenFinishThreshold;

    private void Start()
    {
        if (_onScreenFinishThreshold == null && _onScreenStartThreshold == null)
        {
            _onScreenStartThreshold = GameObject.Find("OnScreenStartThreshold");
            _onScreenFinishThreshold = GameObject.Find("OnScreenFinishThreshold");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _onScreenStartThreshold)
        {
            _bomb.AddOnScreenAnimal(gameObject);
        }

        if (other.gameObject == _onScreenFinishThreshold)
        {
            _bomb.RemoveOnScreenAnimal(gameObject);
        }
    }
}