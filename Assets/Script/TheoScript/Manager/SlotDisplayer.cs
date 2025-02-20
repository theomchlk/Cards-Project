using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDisplayer : MonoBehaviour, IPointerClickHandler
{

    public GameObject Hand;
    public GameObject Player;
    private static GameObject selectedCard = null;

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log(transform.parent.gameObject == Hand);
        if (transform.parent.gameObject == Hand && transform.childCount > 0){
            selectedCard = transform.GetChild(0).gameObject;
            if (transform.parent.parent == Player && transform.childCount == 0){
                selectedCard.transform.SetParent(transform);
                selectedCard.transform.localPosition = Vector3.zero;
            }
        }
    }
}
