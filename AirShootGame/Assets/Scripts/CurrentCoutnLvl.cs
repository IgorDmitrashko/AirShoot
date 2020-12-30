using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentCoutnLvl : MonoBehaviour
{
    public Text currentLvlText;
    private int _countlvl = 1;


    private void Start() {
        currentLvlText.text = _countlvl.ToString();
    }

    public void UpLvl() {
        ++_countlvl;
        currentLvlText.text = _countlvl.ToString();
    }
}
