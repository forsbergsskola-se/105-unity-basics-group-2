using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour, Brick.IBeginDragHandler, Brick.IDragHandler, Brick.IEndDragHandler
{
    
    void Awake()
    {
        transform.position += transform.right * Random.Range(-.1f, .1f);
        
    }
    public interface IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public interface IDragHandler 
    {
        public void OnDrag(PointerEventData eventData)
        {
            Plane plane = new Plane(Vector3.up, Vector3.up * eventData.pointerPressRaycast.worldPosition.y);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out float distance))
            {
                transfrom.position = ray.GetPoint(distance);
            }
        }
    }

    public interface IEndDragHandler 
    {
        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    
}
