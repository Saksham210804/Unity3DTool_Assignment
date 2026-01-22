using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Handles Selection of Game Components in the scene
/// </summary>
public class SelectionManager : MonoBehaviour
{
    #region Fields
    private bool selected = false;
    private GameComponents currentSelected;
    [SerializeField]private UIManager uiManager;
    #endregion

    #region Properties
    /// <summary>
    /// Returns whether an object is currently selected
    /// </summary>
    public bool Selected
    {
        get { return selected; }
    }

    /// <summary>
    /// Returns the currently selected Game Component
    /// </summary>
    public GameComponents CurrentSelected
    {
        get { return currentSelected; }
    }
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseInput();
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Checks for mouse input to select/deselect objects every frame, if left mouse button is clicked it shoots a ray
    /// and checks if the object that is hit has a GameComponent script or not, if yes then it select else it deselects.
    /// We use EventSystem.current.IsPointerOverGameObject() to check if the mouse is over a UI element,
    /// if yes then we don't deselect the game object.
    /// </summary>
    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (Physics.Raycast(ray, out hit))
            {
                GameComponents gameComponent = hit.collider.GetComponent<GameComponents>();
                if (gameComponent != null)
                {
                    Select(gameComponent);
                }
            }
            else
            {
                Deselect();
            }

        }
    }
    /// <summary>
    /// This method select the gameObject which is clicked and shows the transform UI and also changes the color by calling
    /// Select() method of GameComponents script.
    /// </summary>
    /// <param name="gameComponent">Gives the detail of gameObject that is to be selected</param>
    private void Select(GameComponents gameComponent)
    {
        if (currentSelected == gameComponent)
        {
            return;
        }
        Deselect();
        currentSelected = gameComponent;
        currentSelected.Select();
        selected = true;
        uiManager.ShowTransform();
    }
    /// <summary>
    /// Deselects a gameobject if mouse is clicked on empty space or on any other object and the 
    /// current object needs to get deselected and also hides the transform UI.
    /// </summary>
    private void Deselect()
    {
        if (currentSelected == null)
            return;
        if (currentSelected != null)
        {
            currentSelected.Deselect();
            currentSelected = null;
            selected = false;
        }
        uiManager.HideTransform();
    }
    #endregion
}
