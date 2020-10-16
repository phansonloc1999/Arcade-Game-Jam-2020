using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_moveSpeed != 0)
        {
            transform.position -= new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
