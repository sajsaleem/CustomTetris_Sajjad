using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlockMovementHandler : MonoBehaviour, IBlockMovementHandler
{
    #region serialized fields
    [SerializeField] private BlockState _blockState;
    [SerializeField] private BlockType _blockType;
    [SerializeField] private Transform rotationPivot;
    [SerializeField] private BaseBlockSettings blockSettings;
    #endregion

    #region private fields
    private Rigidbody _myRigidBody;
    private ConstantForce _constantForce;
    private Transform placementHighlighter;
    private bool rotatePiece = default;
    private bool isAddedToTower = default;
    private float targetRotation = default;
    private float rotationSpeed = default;
    private float fallSpeed = default;
    private float placedheight = default;
    private float _gravity = default;
    private IPlayerProgressTracker playerProgressTracker;
    #endregion

    #region properties
    public bool IsPlaced { get; private set; } = default;
    public bool IsMoveable { get; private set; } = default;
    public bool MyRigidBody { get => _myRigidBody; }
    public bool IsActive { get => gameObject.activeInHierarchy;}
    public BlockState BlockState { get => _blockState; }
    public BlockType BlockType { get => _blockType; }
    public Vector3 LocalScale { get => transform.localScale; }
    public Vector3 Position { get => transform.position; }
    public BaseBlockSettings BlockSettings { get => blockSettings; }

    #endregion

    #region Virtual Functions
    public virtual void Initialize(IPlayerProgressTracker _playerProgressTracker, Transform highlighter)
    {
        _myRigidBody ??= GetComponent<Rigidbody>();
        _constantForce ??= GetComponent<ConstantForce>();
        _myRigidBody.freezeRotation = false;
        _constantForce.force = blockSettings.blockData.gravity;
        _constantForce.enabled = false;
        IsPlaced = false;
        IsMoveable = true;
        rotatePiece = false;
        UpdatePieceState(BlockState.Falling);
        placedheight = 0;
        playerProgressTracker = _playerProgressTracker;
        placementHighlighter = highlighter;
        float xScale = CalculationsStaticClass.GetChildrenScale(rotationPivot);
        placementHighlighter.localScale = new Vector3(xScale, placementHighlighter.localScale.y, placementHighlighter.localScale.z);
    }

    public virtual void MyEnable()
    {
        targetRotation = blockSettings.blockData.targetRotation;
        rotationSpeed = blockSettings.blockData.rotationSpeed;
        fallSpeed = blockSettings.CalculateNormalFallSpeed();



    }

    public virtual void RotatePiece()
    {
        if (IsPlaced || !IsMoveable)
            return;

        targetRotation = rotationPivot.rotation.eulerAngles.z + 90.0f;

        if (targetRotation >= 360.0f)
        {
            targetRotation -= 360.0f;
        }

        rotatePiece = true;
    }

    public virtual void MovePieceSideWays(float moveAmount)
    {
        if (!IsMoveable)
            return;

        if (!IsMoveable)
            return;

#if UNITY_ANDROID || UNITY_IOS
        transform.position += new Vector3(Mathf.Sign(moveAmount) * 5f * Time.deltaTime, 0, 0);
#endif
#if UNITY_EDITOR
        transform.position += new Vector3(Mathf.Sign(moveAmount) * 10 * Time.deltaTime, 0, 0);
#endif

    }

    public virtual void MyUpdate()
    {
        if (rotatePiece)
        {
            float rotateValue = Mathf.MoveTowardsAngle(rotationPivot.rotation.eulerAngles.z, targetRotation, rotationSpeed * Time.unscaledDeltaTime);
            rotationPivot.rotation = Quaternion.Euler(0f, 0f, rotateValue);

            HandleRotationDisable(rotateValue);
        }

        placementHighlighter.position = new Vector3(rotationPivot.position.x, placementHighlighter.position.y, placementHighlighter.position.z);

    }

    public virtual void FreeFallPiece()
    {
        fallSpeed = blockSettings.CaclulateFreeFallSpeed();
        IsMoveable = false;
        UpdatePieceState(BlockState.FreeFall);
    }

    public virtual void Reset()
    {
        _myRigidBody.useGravity = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rotationPivot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        transform.position = Vector3.zero;
        _myRigidBody.freezeRotation = true;
        placedheight = 0;
        isAddedToTower = false;
    }

    public virtual void RemoveBlockHeightFromTower()
    {
        playerProgressTracker.RemoveBlock(rotationPivot);
    }
    #endregion

    #region Private Functions

    private void HandleRotationDisable(float rotateValue)
    {
        if (Mathf.Approximately(rotateValue, targetRotation))
        {
            rotatePiece = false;
            float xScale = CalculationsStaticClass.GetChildrenScale(rotationPivot);

            placementHighlighter.localScale = new Vector3(xScale, placementHighlighter.localScale.y, placementHighlighter.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        if (!IsPlaced)
        {
            _myRigidBody.velocity = new Vector3(0, fallSpeed, 0);
        }

        if (IsPlaced)
        {
            AddToTowerHeight();
        }

        if(_myRigidBody.velocity.magnitude <= 0.005f)
        {
            UpdatePieceState(BlockState.InStableState);
        }
        else
        {
            UpdatePieceState(BlockState.Falling);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        IBlockMovementHandler ipieceMovmentHandler = collision.gameObject.GetComponent<IBlockMovementHandler>();

        if (collision.gameObject.CompareTag("surface") || (ipieceMovmentHandler != null && ipieceMovmentHandler.IsPlaced))
        {
            IsPlaced = true;
            IsMoveable = false;
            _constantForce.enabled = true;
            UpdatePieceState(BlockState.IsPlaced);
        }
    }

    private void UpdatePieceState(BlockState blockState)
    {
        if (_blockState != blockState)
            _blockState = blockState;
    }

    private void AddToTowerHeight()
    {
        if (placedheight <= 0 && _blockState == BlockState.InStableState && !isAddedToTower)
        {
            playerProgressTracker.AddBlock(rotationPivot);
            isAddedToTower = true;
        }
    }
    #endregion
}
