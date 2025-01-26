using UnityEngine;

public class buttonDoor : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveDistance = 20f;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private int objectsOnButton = 0;

    void Start()
    {
        originalPosition = objectToMove.transform.position;
        targetPosition = originalPosition + Vector3.down * moveDistance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Je suis juste sur le bouton");
        objectsOnButton++;
        if (objectsOnButton > 0)
        {
            Debug.Log("Je suis sur le bouton dans le if");
            objectToMove.transform.position = targetPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Je suis nul part");
        objectsOnButton--;
        if (objectsOnButton <= 0)
        {
            objectToMove.transform.position = originalPosition;
            objectsOnButton = 0;
        }
    }
}
