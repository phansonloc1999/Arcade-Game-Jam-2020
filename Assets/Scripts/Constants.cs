using System;
using UnityEngine;

public class Constants : MonoBehaviour
{
    private static Constants _instance;

    public static Constants Instance { get { return _instance; } }

    private Vector3 _topLeftScreenWorldPos;

    public Vector3 TopLeftScreenWorldPos { get => _topLeftScreenWorldPos; set => _topLeftScreenWorldPos = value; }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;

            Initialize();
        }
    }



    private void Update()
    {

    }

    private void Initialize()
    {
        TopLeftScreenWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}