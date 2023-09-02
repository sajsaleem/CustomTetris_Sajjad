using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTest : MonoBehaviour
{
    [SerializeField] private float fallSpeed = default;
    //[SerializeField] private Transform groupOfChildren;

    Rigidbody myRigidBody;

    float yVelocity;
    float targetRotation = default;

    private bool isPlaced = default;
    private bool rotateObject = default;
    private bool isDragging = false;
    private Vector3 dragStartPosition;
    private Vector3 startPosition;


    private void Start()
    {
        myRigidBody ??= GetComponent<Rigidbody>();
        yVelocity = fallSpeed * Physics.gravity.y;
    }

    private void Update()
    {
        //if (rotateObject)
        //{
        //    float rotateVal = Mathf.MoveTowardsAngle(groupOfChildren.rotation.eulerAngles.z, targetRotation, 300 * Time.unscaledDeltaTime);
        //    groupOfChildren.rotation = Quaternion.Euler(0f, 0f, rotateVal);

        //    if (Mathf.Approximately(rotateVal, targetRotation))
        //    {
        //        rotateObject = false;
        //    }

        //}

        //if (isDragging)
        //{
        //    // Calculate the difference in mouse position since drag start
        //    Vector3 mouseDelta = Input.mousePosition - dragStartPosition;

        //    // Convert mouse movement to world space
        //    Vector3 worldDelta = Camera.main.ScreenToWorldPoint(mouseDelta) - Camera.main.ScreenToWorldPoint(Vector3.zero);

        //    // Apply sideways movement along the X-axis (or Y-axis, depending on your preference)
        //    transform.position += new Vector3(worldDelta.x, 0f, 0f);

        //    // Update the drag start position
        //    dragStartPosition = Input.mousePosition;
        //}
    }

    private void FixedUpdate()
    {
        if(!isPlaced)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, yVelocity, myRigidBody.velocity.z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("surface") || collision.gameObject.CompareTag("placedObject"))
        {
            isPlaced = true;
            myRigidBody.useGravity = true;
        }
    }

    //private void OnMouseOver()
    //{
    //    //if(Input.GetMouseButtonDown(0))
    //    //{
    //    //        targetRotation = groupOfChildren.rotation.eulerAngles.z + 90.0f;

    //    //        if (targetRotation >= 360.0f)
    //    //        {
    //    //            targetRotation -= 360.0f;
    //    //        }

    //    //        rotateObject = true;

    //    //}
    //}

    //private void OnMouseDown()
    //{
    //    if(!isPlaced)
    //        startPosition = Input.mousePosition;
    //}

    //private void OnMouseDrag()
    //{
    //    if(!isPlaced)
    //    {
    //        isDragging = true;
    //        dragStartPosition = Input.mousePosition;
    //    }
    //}

    //void OnMouseUp()
    //{
    //    if (isPlaced)
    //        return;

    //    isDragging = false;

    //    if (Mathf.Abs(Input.mousePosition.x - startPosition.x) > 0.1)
    //        return;

    //    targetRotation = groupOfChildren.rotation.eulerAngles.z + 90.0f;

    //    if (targetRotation >= 360.0f)
    //    {
    //        targetRotation -= 360.0f;
    //    }

    //    rotateObject = true;

    //}
}
