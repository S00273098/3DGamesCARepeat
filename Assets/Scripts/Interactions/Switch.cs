using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public Door door;

    private bool activated = false;

    public bool IsActivated => activated;

    public void Interact()
    {
        if (activated)
            return;

        activated = true;

        door.Open();

        Debug.Log("Switch activated!");
    }

    public void LoadState(bool state)
    {
        activated = state;

        if (activated)
        {
            door.Open();
        }
    }
}