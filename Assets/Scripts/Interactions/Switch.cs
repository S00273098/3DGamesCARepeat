using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public Door door;

    private bool activated = false;

    public void Interact()
    {
        if (activated)
            return;

        activated = true;

        door.Open();

        Debug.Log("Switch activated!");
    }
}