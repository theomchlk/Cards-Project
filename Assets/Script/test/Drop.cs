using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Récupérer l'objet qui est en train d'être déplacé
        GameObject droppedObject = eventData.pointerDrag;

        // Vérifier si c'est une carte draggable
        if (droppedObject != null && droppedObject.GetComponent<Drag>() != null)
        {
            // Placer la carte dans ce slot
            droppedObject.transform.SetParent(transform);
            droppedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            Debug.Log($"Carte {droppedObject.name} déposée dans {gameObject.name}");
        }
    }
}
