using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Droppable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    private Image image;
    private RectTransform rect;
    private Image droppedImage; // 드롭된 이미지를 저장할 변수
    private Transform originalPosition; // 드래그된 이미지의 원래 부모를 저장할 변수

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = Color.white;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Transform draggedObject = eventData.pointerDrag.transform;
            Image draggedImage = draggedObject.GetComponent<Image>();

            if (droppedImage == null) // 처음 이미지 드롭
            {
                // 새로운 이미지 추가
                droppedImage = draggedImage;
                originalPosition = draggedObject.parent; // 드래그된 이미지의 원래 부모 저장
                draggedObject.SetParent(transform); // 부모 변경
                draggedObject.GetComponent<RectTransform>().position = rect.position; // 위치 설정
            }
            else if (draggedObject != droppedImage.transform) // 다른 이미지 드롭
            {
                // 원래 이미지 자리로 되돌리기
                droppedImage.GetComponent<Draggable>().Reset();
                //droppedImage.transform.SetParent(originalPosition);
                //droppedImage.transform.GetComponent<RectTransform>().position = originalPosition.GetComponent<RectTransform>().position;

                // 새로운 이미지 추가
                droppedImage = draggedImage;
                originalPosition = draggedObject.parent; // 드래그된 이미지의 원래 부모 저장
                draggedObject.SetParent(transform); // 부모 변경
                draggedObject.GetComponent<RectTransform>().position = rect.position; // 위치 설정
            }
        }
    }
}
