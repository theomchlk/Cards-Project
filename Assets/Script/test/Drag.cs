using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    public Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    // Début du drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;  // Mémorise le parent d'origine
        transform.SetParent(canvas.transform);
        canvasGroup.alpha = 0.6f; // Rendre semi-transparent
        canvasGroup.blocksRaycasts = false; // Permettre au DropHandler de détecter l'objet derrière
    }

    // Pendant le drag
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    // Fin du drag
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;


        // Si l'objet n'a pas été déplacé dans un slot, le ramener à sa position initiale
        if (transform.parent == originalParent || transform.parent == canvas.transform)
        {
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
