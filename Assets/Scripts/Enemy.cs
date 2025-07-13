using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{

    [SerializeField] private int _lifePoints = 3;

    public void Interact()
    {
        Debug.Log($"{gameObject.name} colpito. Life Points rimanenti: {_lifePoints}");
        _lifePoints--;
        if( _lifePoints == 0 ) Destroy(gameObject);
    }

}
