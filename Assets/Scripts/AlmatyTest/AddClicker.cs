using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddClicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private MoveController _moveController;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        _moveController.AddPoint();
    }

}
