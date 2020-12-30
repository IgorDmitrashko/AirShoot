using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubsController : MonoBehaviour
{
    [SerializeField] private ClickController _clickController;
    [SerializeField] private MeshRenderer[] _meshs;

    private RaycastHit _hit;

    [SerializeField] private Material _activeCube;
    [SerializeField] private Material _dontActiveCube;

    private Material _defaultCube;


    private void Start() {
        if(_meshs != null)
            _defaultCube = _meshs[0].material;
        _clickController.SetMaterialCube += SetMaterialCubs;
        _clickController.ResetMaterial += ResetMaterial;
    }

    private void SetMaterialCubs(MeshRenderer activeCube) {
        foreach(var item in _meshs)
        {
            item.material = _dontActiveCube;
        }

        activeCube.material = _activeCube;
    }

    private void ResetMaterial() {
        foreach(var item in _meshs)
        {
            item.material = _defaultCube;
        }
    }


}
