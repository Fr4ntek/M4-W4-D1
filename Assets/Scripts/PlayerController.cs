using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;

    private float _mouseMovement;

    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        _mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, _mouseMovement * _rotationSpeed, 0)); //modifica anche il forward
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * v + transform.right * h;
        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));

        // oppure Vector3 direction = new Vector3(h, 0, v);
        // Vector3 moveDir = transform.TransformDirection(direction).normalized; gia tiene conto della rotazione
        // _rb.MovePosition(_rb.position + moveDir * (_speed * Time.fixedDeltaTime));

    }
}
