using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputManager : MonoBehaviour ,IPlayerInputManager
{
    [SerializeField] private float tapInterval = default;
    [SerializeField] private bool isTouchActive = default;

    public float TapInterval { get => tapInterval; }
    public bool IsTouchActive { get => isTouchActive; }
    public IBlockSpawner BlockSpawner { get; private set; } = default;


    private Vector3 startPressPosition;
    private Vector3 endPressPosition;
    private float touchPhaseStart = default;

    private void Start()
    {
        BlockSpawner = GetComponent<IBlockSpawner>();
    }

    void Update()
    {
        MyUpdate();
    }

    public void MyUpdate()
    {
        if (isTouchActive)
        {
#if UNITY_EDITOR
            HandleMouseInput();
#endif

#if UNITY_ANDROID || UNITY_IOS
            HandleTouchInput();
#endif
        }
    }

    public void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ScreenTouchBegan(Input.mousePosition);
        }

        else if (Input.GetMouseButton(0))
        {
            endPressPosition = Input.mousePosition;
            ManagePieceMovement();
        }

        else if (Input.GetMouseButtonUp(0))
        {
            endPressPosition = Input.mousePosition;
            ScreenTouchEnd();
        }
    }

    public void HandleTouchInput()
    {
        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount > 0 && PointerOverUi(touch.fingerId))
                return;

            if (touch.phase == TouchPhase.Began)
            {
                startPressPosition = touch.position;
                endPressPosition = touch.position;
                touchPhaseStart = Time.time;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                endPressPosition = touch.position;
                ManagePieceMovement();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPressPosition = touch.position;
                ScreenTouchEnd();
            }
        }
    }

    public void ManagePieceMovement()
    {
        Vector3 swipeDirection = (endPressPosition - startPressPosition).normalized;

        //// Check if the swipe distance is larger than the threshold
        if (swipeDirection.x >= 0.5f || swipeDirection.x <= -0.5f)
        {
            MoveObject(swipeDirection.x);

            // Update the mouse start position for the next frame
            startPressPosition = endPressPosition;
        }
    }

    public void ScreenTouchBegan(Vector3 _position)
    {
        startPressPosition = _position;
        touchPhaseStart = Time.time;
    }

    public void ScreenTouchEnd()
    {

        Vector3 swipeDirection = endPressPosition - startPressPosition;

        if ((Time.time - touchPhaseStart < tapInterval) && swipeDirection.magnitude <= 0.2)
        {
            RotateObject();
        }
    }

    private void MoveObject(float moveAmount)
    {
        if (BlockSpawner != null && BlockSpawner.NewBlock != null)
            BlockSpawner.NewBlock.MovePieceSideWays(moveAmount);
    }

    public void RotateObject()
    {
        if (BlockSpawner != null && BlockSpawner.NewBlock != null)
            BlockSpawner.NewBlock.RotatePiece();
    }

    private bool PointerOverUi(int touchid)
    {
        return EventSystem.current.IsPointerOverGameObject(touchid);
    }
}
