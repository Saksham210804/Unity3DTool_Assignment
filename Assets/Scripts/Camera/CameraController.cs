using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all the Camera logic like Zoom, Rotate, Pan and Focus.
/// </summary>
public class CameraController : MonoBehaviour
{
    #region Fields
    private float zoomMagnitude;
    [SerializeField]
    private float mouseSensitivity = 5.0f;
    [SerializeField]
    private float panSpeed = 0.5f;
    [SerializeField]
    private float focusDistance = 5f;
    private float yaw = 0f;
    private float pitch = 0f;
    [SerializeField] private SelectionManager selectionManager;
    private GameComponents focusGameComponent;
    private Vector3 focusPos;
    #endregion

    #region UnityMethods
    // Update is called once per frame
    void Update()
    {
        ZoomCamera();
        RotateCamera();
        PanCameraMovement();
        FocusOnSelectedObject();
        Defocus();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Handles zooming the camera in and out on the basis of scroll input which is saved inside a float field zoomMagnitude.
    /// </summary>
    private void ZoomCamera()
    {
        Vector2 zoom = Input.mouseScrollDelta;
        zoomMagnitude = zoom.y;
        transform.position += transform.forward * zoomMagnitude;
    }
    /// <summary>
    /// It enables the camera to rotate only if the right mouse button is held down.
    /// It takes continuous input from the mouse movement along the X and Y axes to adjust the yaw and pitch of the camera respectively.
    /// Then according to yaw and pitch the camera's rotation is updated using Quaternion.Euler to create a smooth rotational effect.
    /// </summary>
    private void RotateCamera()
    {
        if (Input.GetButton("Fire2"))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            yaw += mouseX;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -90f, 90f);
            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }
    /// <summary>
    /// It handles Pan camera movement when the middle mouse button is held down. The pan movement happens only in X and Y axes so we again take continuous
    /// input from the mouse movement along the X and Y axes and multiply it by a panSpeed factor to control the speed of panning. Then we calculate the panPosition
    /// using a Vector3 and change it regularly according to the camera's right and up directions. Finally, we update the camera's position by
    /// adding the panPosition to it. [Note - we use -negative mouseX and mouseY to invert the panning direction according to Unity Coordinate System.]
    /// </summary>
    private void PanCameraMovement()
    {
        if (Input.GetButton("Fire3"))
        {
            float mouseX = Input.GetAxis("Mouse X")*panSpeed;
            float mouseY = Input.GetAxis("Mouse Y")*panSpeed;
            
            Vector3 panPosition = (transform.right * -mouseX) + (transform.up * -mouseY);
            transform.position += panPosition;
        }
    }
    /// <summary>
    /// This method first checks if there is a selected object using the selectionManager.
    /// then it retrieves the currently selected object and save that inside GameComponents class object.
    /// then it checks for keyboard "L" key input and accordingly call another function CameraMovementTowardsSelectedObject(GameComponents selectedObject).
    /// </summary>
    private void FocusOnSelectedObject()
    {
        if (selectionManager.Selected)
        {
            
            GameComponents selectedObject = selectionManager.CurrentSelected;
            if(Input.GetKeyDown(KeyCode.L))
            {
             CameraMovementTowardSelectedObject(selectedObject);
            }
        }
    }
    /// <summary>
    /// This function is called inside FocusOnSelectedObject() method.
    /// It handles camera focus movement and also checks if the camera is already focused on the selected object.
    /// It firstly saves the selected object inside focusGameComponent field. then it calculates the direction vector and using the formula (Target - Source).normalized.
    /// Where Target is the selected object's position and Source is the camera's current position.
    /// Then it updates the camera's position to be at a certain distance (focusDistance) away from the selected object in the calculated direction.
    /// It also uses transform.LookAt to ensure the camera is oriented towards the selected object after repositioning.
    /// It also saves the camera's current position inside focusPos field which is later used inside Defocus() method.
    /// </summary>
    /// <param name="selectedObject">Handles information about the gameObject that is selected</param>
    private void CameraMovementTowardSelectedObject(GameComponents selectedObject)
    {
        if (focusGameComponent == selectedObject)
        {
            return;
        }
        focusGameComponent = selectedObject; 

        Vector3 direction =
            (transform.position - selectedObject.ObjectPosition ).normalized;

        transform.position =
            selectedObject.ObjectPosition + direction * focusDistance;

        transform.LookAt(selectedObject.ObjectPosition);

        focusPos = transform.position;
    }
    /// <summary>
    /// It checks for different conditions to determine if the camera should defocus from the currently focused object and is called every frame inside Update.
    /// First, it checks if there is no currently selected object using selectionManager.
    /// Then it checks if the focusGameComponent is not null and if it is different from the currently selected object and then makes focusGameComponent null which
    /// basically enables the focus camera movements. Lastly, it checks if the camera's current position is different from the saved focusPos which then enables focus
    /// movement again.
    /// </summary>
    private void Defocus()
    {
        if (selectionManager.CurrentSelected == null)
        {
            focusGameComponent = null;
        }

        if (focusGameComponent != null &&
       focusGameComponent != selectionManager.CurrentSelected)
        {
            focusGameComponent = null;
        }
        
        if(focusPos != transform.position)
        {
            focusGameComponent = null;
        }
    }
    #endregion
}
