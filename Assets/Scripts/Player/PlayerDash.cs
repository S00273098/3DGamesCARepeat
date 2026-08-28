using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.15f;
    public float cooldown = 2f;

    private PlayerInputActions inputActions;
    private Rigidbody rb;

    private bool isDashing;
    private float nextDashTime;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        if (inputActions.Player.Dash.WasPressedThisFrame())
        {
            TryDash();
        }
    }

    private void TryDash()
    {
        if (isDashing || Time.time < nextDashTime)
            return;

        StartCoroutine(Dash());
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        nextDashTime = Time.time + cooldown;

        Vector3 startPosition = rb.position;
        Vector3 direction = transform.forward;
        Vector3 targetPosition = startPosition + direction * dashDistance;

        if (Physics.Raycast(
            startPosition,
            direction,
            out RaycastHit hit,
            dashDistance))
        {
            targetPosition = hit.point - direction * 0.5f;
        }

        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            elapsed += Time.deltaTime;

            float progress = elapsed / dashDuration;

            rb.MovePosition(
                Vector3.Lerp(startPosition, targetPosition, progress)
            );

            yield return null;
        }

        isDashing = false;
    }
}