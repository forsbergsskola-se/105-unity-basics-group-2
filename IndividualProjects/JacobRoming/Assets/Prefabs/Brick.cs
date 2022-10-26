using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Brick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += transform.right * Random.Range(-.1f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Kinda jank but there probably isnt a better way to do it without implementing more sophisticated game logic
        if (transform.position.y < -4 && currentlyColliding.Count == 0)
        {
            //The expensiveness of this wont be too much of a problem since it will rarely be run
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        currentlyColliding.Remove(other);
    }

    private List<Collision> currentlyColliding = new List<Collision>();

    private void OnCollisionEnter(Collision other)
    {
        currentlyColliding.Add(other);
    }
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Plane plane = new Plane(Vector3.up, Vector3.up * eventData.pointerPressRaycast.worldPosition.y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            transform.position = ray.GetPoint(distance);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
