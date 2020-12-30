using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    //public GameObject Ball;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("rrrr");
        if(Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x))
        {
            if(eventData.delta.y > 0)
                Debug.Log("Свайп начался");
            //Instantiate(Ball, new Vector3(5f, 1.66f, 2.91f), Quaternion.identity);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("Свайп закончен");
    }
}
