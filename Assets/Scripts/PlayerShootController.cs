using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _rayLenght = 10f;

    private GameObject _lastHitObject;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_firePoint == null) return;
        Gizmos.DrawLine(_firePoint.position, _firePoint.position + _firePoint.forward * _rayLenght);
    }


    void Start()
    {
        
    }

    void Update()
    {
        if(_firePoint == null) return;
        if(Physics.Raycast(_firePoint.position, _firePoint.forward, out RaycastHit hitInfo, _rayLenght))
        {
            GameObject currentHit = hitInfo.collider.gameObject;
            if (currentHit != _lastHitObject)
            {

                if(hitInfo.collider.TryGetComponent<IInteractable>(out IInteractable _interface))
                {
                    _interface.Interact();
                    _lastHitObject = currentHit;
                }   
            }
        }
        else
        {
            _lastHitObject = null;
        }
        
    }
}
