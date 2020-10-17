using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGunAim : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        _collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
