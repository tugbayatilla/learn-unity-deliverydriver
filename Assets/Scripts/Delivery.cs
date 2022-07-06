using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] private float destroyDelay = 0.5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private bool _hasPackage;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Hit");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !_hasPackage)
        {
            Debug.Log("Package picked up.");
            _hasPackage = true;
            _spriteRenderer.color = hasPackageColor;
            Destroy(col.gameObject, destroyDelay);
        }

        if (col.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Customer got the package");
            _hasPackage = false;
            _spriteRenderer.color = noPackageColor;
        }
    }
}