using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    public Animator animator;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.SetActive(false);
            animator.SetBool("correctItem",true);
            //After 1 second run the IsHappy function
            Invoke("IsHappy", 0.8f);
            Debug.Log("Dropped Item in Child");
        }
       
    }
    private void IsHappy()
    {
        animator.SetBool("correctItem",false);
        Debug.Log("waited 0.8 seconds");
    }
}
