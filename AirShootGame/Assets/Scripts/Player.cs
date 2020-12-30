using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action Shot;

    [SerializeField] private Arrow _arrow;  

    void Start() {
        _arrow.ReadyShoot += Shoot;
    }

    private void Shoot(Vector3 vector3, float power) {
        Shot?.Invoke();
    }  
}
