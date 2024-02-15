using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas; //UI 가 소속되어 있는 최상단의 Canvas
    public Transform previousParent; // 해당 오브젝트가 직전에 소속되어 있었던 부모
    public Transform originalParent; // 해당 오브젝트가 직전에 소속되어 있었던 부모
    private RectTransform rect; // UI 위치 제어를 위한
    public int ID;

    private void Awake()
    {
        originalParent = transform.parent;
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();

        if (transform.parent != originalParent)
        {
            GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;
        GetComponent<Image>().raycastTarget = false;
        transform.SetParent(canvas); // 부모 오브젝트를 canvas로
        transform.SetAsLastSibling(); // 가장 앞에 보이도록
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)
        {
            ResetOrigin();
        }
    }

    public void ResetOrigin()
    {
        GetComponent<Image>().raycastTarget = true;
        transform.SetParent(originalParent);
        rect.position = originalParent.GetComponent<RectTransform>().position;
    }

}