using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IEndDragHandler
{
    void OnEndDrag(PointerEventData eventData);
}
