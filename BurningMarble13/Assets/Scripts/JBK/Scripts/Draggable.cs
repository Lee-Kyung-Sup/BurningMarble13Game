using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas; //UI �� �ҼӵǾ� �ִ� �ֻ���� Canvas
    public Transform previousParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    public Transform originalParent; // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ�
    private RectTransform rect; // UI ��ġ ��� ����
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
        transform.SetParent(canvas); // �θ� ������Ʈ�� canvas��
        transform.SetAsLastSibling(); // ���� �տ� ���̵���
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