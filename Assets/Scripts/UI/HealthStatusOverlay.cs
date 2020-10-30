using UnityEngine;
using UnityEngine.UI;

public class HealthStatusOverlay : MonoBehaviour
{
    private static readonly Color[] _colors = new Color[]{
        new Color(1, 0, 1, 1),
        new Color(1, 85/255.2f, 1, 1),
        new Color(85/255.2f, 170/255.2f, 0, 1),
        new Color(85/255.2f, 1, 0, 1),
        new Color(1, 1, 0, 1),
        new Color(1, 1, 85/255.2f, 1),
        new Color(1, 170/255.2f, 0, 1),
        new Color(1, 170/255.2f, 85/255.2f, 1),
        new Color(1, 85/255.2f, 0, 1),
        new Color(1, 85/255.2f, 85/255.2f, 1)
    };

    [SerializeField] private Image _image;

    private void Start()
    {
        PlayerHealth.OnPlayerTakingDamage += UpdateColor;
    }

    public void UpdateColor()
    {
        _image.color = _colors[_colors.Length - PlayerHealth.CurrentHealth];
    }
}