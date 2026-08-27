using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float openDistance = 3f;
    public float openSpeed = 3f;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    private bool isOpen = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + transform.right * openDistance;
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                openPosition,
                openSpeed * Time.deltaTime
            );
        }
    }

    public void Interact()
    {
        Open();
    }

    public void Open()
    {
        isOpen = true;
    }
}