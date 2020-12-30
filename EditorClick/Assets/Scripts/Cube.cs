using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IPointerClickHandler
{
    private Material _randerer;

   [SerializeField] private Material _materialActiv;
   [SerializeField] private Material _materiaDontlActiv;
    private Material _materialDefault;

    

    private void Awake() {
        _randerer = GetComponent<Material>();
    }

    private void Start() {
        _materialDefault = _randerer;
    }

    public void OnPointerClick(PointerEventData eventData) {
        _randerer = _materialActiv;
    }
}
