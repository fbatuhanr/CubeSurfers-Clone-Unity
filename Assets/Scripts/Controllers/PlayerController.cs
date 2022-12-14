using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float horizontalSpeed, verticalSpeed;
    [SerializeField] private float restrictPosX;

    private float HorizontalInput => joystick.Horizontal;
    private float HorizontalMovement => Mathf.Clamp(HorizontalInput*restrictPosX * horizontalSpeed, -restrictPosX, restrictPosX);
    private bool IsInputTouchSwiping => Input.touchCount > 0 && Input.GetTouch(0).phase is TouchPhase.Began or TouchPhase.Moved;
    private bool IsInputClickSwiping => Input.GetMouseButton(0);
    private float VerticalMovement => verticalSpeed * Time.fixedDeltaTime;

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGameContinue) return;
        
        HandleMovement();
    }
    private void HandleMovement()
    {
        var currPosition = transform.position;
        currPosition.x = IsInputTouchSwiping || IsInputClickSwiping ? HorizontalMovement : currPosition.x;
        currPosition.z += GameManager.Instance.IsEnteredToFinishLine ? VerticalMovement*2 : VerticalMovement;

        transform.position = currPosition;
    }

}
