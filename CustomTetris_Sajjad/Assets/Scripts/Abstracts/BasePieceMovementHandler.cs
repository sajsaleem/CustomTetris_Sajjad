using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePieceMovementHandler : MonoBehaviour,  IPieceMovementHandler
{
    #region serialized fields
    [SerializeField] private PieceState _pieceState;
    [SerializeField] private Transform rotationPivot;
    [SerializeField] private BasePieceSettings pieceSettings;
    #endregion

    #region private fields
    private Rigidbody _myRigidBody;
    private bool rotatePiece = default;
    private float targetRotation = default;
    private float rotationSpeed = default;
    private float fallSpeed = default;
    #endregion

    #region properties
    public bool IsPlaced { get; private set; } = default;
    public bool IsMoveable { get; private set; } = default;
    public bool MyRigidBody => _myRigidBody;
    public bool IsActive => gameObject.activeInHierarchy;
    public PieceState PieceState => _pieceState;
    public Vector3 LocalScale => transform.localScale;
    public Vector3 Position => transform.position;
    #endregion

    #region Virtual Functions
    public virtual void Initialize()
    {
        _myRigidBody ??= GetComponent<Rigidbody>();
        _myRigidBody.freezeRotation = false;
        IsPlaced = false;
        IsMoveable = true;
        rotatePiece = false;
        UpdatePieceState(PieceState.Falling);
    }

    public virtual void MyEnable()
    {
        targetRotation = pieceSettings.pieceData.targetRotation;
        rotationSpeed = pieceSettings.pieceData.rotationSpeed;
        fallSpeed = pieceSettings.CalculateNormalFallSpeed();
    }

    public virtual void RotatePiece()
    {
        Debug.Log("Rotate Piece" + IsPlaced);

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

        transform.Translate(new Vector3(moveAmount, 0, 0));
    }

    public virtual void MyUpdate()
    {
        if (rotatePiece)
        {
            float rotateValue = Mathf.MoveTowardsAngle(rotationPivot.rotation.eulerAngles.z, targetRotation, rotationSpeed * Time.unscaledDeltaTime);
            rotationPivot.rotation = Quaternion.Euler(0f, 0f, rotateValue);

            HandleRotationDisable(rotateValue);
        }
    }

    public virtual void FreeFallPiece()
    {
        fallSpeed = pieceSettings.CaclulateFreeFallSpeed();
        IsMoveable = false;
        UpdatePieceState(PieceState.FreeFall);
    }

    public virtual void Reset()
    {
        _myRigidBody.useGravity = false;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        rotationPivot.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        transform.position = Vector3.zero;
        _myRigidBody.freezeRotation = true;
    }
    #endregion

    #region Private Functions
    private void HandleRotationDisable(float rotateValue)
    {
        if (Mathf.Approximately(rotateValue, targetRotation))
        {
            rotatePiece = false;
        }
    }

    private void FixedUpdate()
    {
        if (!IsPlaced)
        {
            _myRigidBody.velocity = new Vector3(0, fallSpeed, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IPieceMovementHandler ipieceMovmentHandler = collision.gameObject.GetComponent<IPieceMovementHandler>();

        if (collision.gameObject.CompareTag("surface") || (ipieceMovmentHandler != null && ipieceMovmentHandler.IsPlaced))
        {
            IsPlaced = true;
            IsMoveable = false;
            _myRigidBody.useGravity = true;
            UpdatePieceState(PieceState.IsPlaced);
            //Managers.PieceSpawner.SpawnPiece();
        }

        //if (collision.gameObject.CompareTag("surface") || collision.gameObject.CompareTag("Block"))
        //{
        //    IsPlaced = true;
        //    IsMoveable = false;
        //    _myRigidBody.useGravity = true;
        //    UpdatePieceState(PieceState.IsPlaced);
        //    Debug.Log("")
        //    //Managers.PiecesObjectPooler.UpdateActivePieceReference(null);
        //}
    }

    private void UpdatePieceState(PieceState pieceState)
    {
        _pieceState = pieceState;
    }
    #endregion
}
