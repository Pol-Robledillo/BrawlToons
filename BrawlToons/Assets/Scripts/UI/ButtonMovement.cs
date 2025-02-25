using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverMoveLerp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    public float moveDistance = 10f;
    public float moveSpeed = 5f;

    private void Start()
    {
        originalPosition = transform.localPosition;
        targetPosition = originalPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPosition = originalPosition + new Vector3(moveDistance, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPosition = originalPosition;
    }
}