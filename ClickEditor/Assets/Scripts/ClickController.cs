using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour, IPointerClickHandler
{
    public Action ResetMaterial;
    public Action<MeshRenderer> SetMaterialCube;

    private RaycastHit _hit;

    public void OnPointerClick(PointerEventData eventData) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out _hit, 100))
        {
            if(Physics.Raycast(ray))
            {
                MeshFilter filter = _hit.collider.GetComponent(typeof(MeshFilter)) as MeshFilter;              
                SetMaterialCube?.Invoke(filter.gameObject.GetComponent<MeshRenderer>());
            }
        }
    }

    public void ResetMaterialsCube() {
        ResetMaterial?.Invoke();
    }
}
