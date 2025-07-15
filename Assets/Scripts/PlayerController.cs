using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Transform _cameraTransform;

    private float _mouseMovement;
    private Vector3 _camForward;
    private Vector3 _camRight;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // commento per esercizio 2.2 - il Mouse X mi serve per la telecamera in terza persona
        //_mouseMovement = Input.GetAxis("Mouse X");
        //transform.Rotate(new Vector3(0, _mouseMovement * _rotationSpeed, 0)); //modifica anche il forward
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Esercizio 2.2 - TPS
        _camForward = _cameraTransform.forward.normalized;
        _camRight = _cameraTransform.right.normalized;

        _camForward.y = 0f;
        _camRight.y = 0f;

        Vector3 directionTps = (v *_camForward + h * _camRight).normalized;

        // commento per esercizio 2.2 e ripristino movimento classico
        //Vector3 direction = transform.forward * v + transform.right * h;

        // commento per esercizio 2.2
        //Vector3 direction = new Vector3(h,0,v).normalized;

        if (directionTps.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionTps), _rotationSpeed * Time.fixedDeltaTime);

        }
        _rb.MovePosition(_rb.position + directionTps * (_speed * Time.fixedDeltaTime));

        // oppure Vector3 direction = new Vector3(h, 0, v);
        // Vector3 moveDir = transform.TransformDirection(direction).normalized; gia tiene conto della rotazione
        // _rb.MovePosition(_rb.position + moveDir * (_speed * Time.fixedDeltaTime));

    }
}
