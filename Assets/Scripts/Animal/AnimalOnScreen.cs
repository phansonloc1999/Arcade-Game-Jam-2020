using UnityEngine;

public class AnimalOnScreen : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private bool _isOnScreen;
    public bool IsOnScreen { get => _isOnScreen; set => _isOnScreen = value; }

    private static GameObject _onScreenStartThreshold;
    private static GameObject _onScreenFinishThreshold;

    public delegate void CrossingOnScreenStartThreshold();

    public event CrossingOnScreenStartThreshold OnCrossingOnScreenStartThreshold;

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

            OnCrossingOnScreenStartThreshold?.Invoke();
        }

        if (other.gameObject == _onScreenFinishThreshold)
        {
            _bomb.RemoveOnScreenAnimal(gameObject);
        }
    }
}