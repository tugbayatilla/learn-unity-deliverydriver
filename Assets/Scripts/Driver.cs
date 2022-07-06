using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [FormerlySerializedAs("moveSpeed")] [SerializeField] float normalSpeed = 20f;
    [SerializeField] float fastSpeed = 30f;
    [SerializeField] float slowSpeed = 15f;
    float _currentSpeed = 20f;

    void Start()
    {
        _currentSpeed = normalSpeed;
    }

    void Update()
    {
        const float reverseConstant = -1;
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * reverseConstant * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * _currentSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0 , moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
            _currentSpeed = slowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("SpeedUp"))
        {
            _currentSpeed = fastSpeed;
        }

        if (col.CompareTag("Customer"))
        {
            _currentSpeed = normalSpeed;
        }
    }
}
