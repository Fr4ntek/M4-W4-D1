using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Transform> _transforms = new List<Transform>();

    public void Interact()
    {
        if (_transforms.Count > 0)
        {
            transform.position = _transforms[Random.Range(0, _transforms.Count)].position;
        }
    }
}
