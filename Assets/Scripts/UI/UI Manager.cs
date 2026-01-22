using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/// <summary>
/// Handles all the UI interactions.
/// </summary>
public class UIManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private ObjectSpawner objectSpawner;
    [SerializeField] private SelectionManager selectionManager;
    [SerializeField] private TMP_InputField objectXPosition;
    [SerializeField] private TMP_InputField objectYPosition;
    [SerializeField] private TMP_InputField objectZPosition;
    [SerializeField] private GameObject TransformPanel;
    [SerializeField] private GameObject ComponentsPanel;
    private bool showComponents = true;
    private Vector3 Origin = new Vector3(0, 0, 0);
    private Vector3 objectPosition;
    #endregion

    #region Public Methods
    /// <summary>
    /// Handles the functionality of the Add button which is the only visible button in the start of the game
    /// It set activates the Components panel which contains buttons for spawning object.
    /// </summary>
    public void AddButton()
    {
        if(showComponents)
        {
            ComponentsPanel.SetActive(true);
            showComponents = false;
        }
        else
        {
            ComponentsPanel.SetActive(false);
            showComponents = true;
        }
    }

    /// <summary>
    /// Spawns a capsule object by passing enum value to SpawnButton function
    /// </summary>
    public void SpawnCapsule()
    {
        SpawnButton(GameObjects.Capsule);
    }

    /// <summary>
    /// Spawns a cube object by passing enum value to SpawnButton function
    /// </summary>
    public void SpawnCube()
    {
        SpawnButton(GameObjects.Cube);
    }

    /// <summary>
    /// Spawns a cylinder object by passing enum value to SpawnButton function
    /// </summary>
    public void SpawnCylinder()
    {
        SpawnButton(GameObjects.Cylinder);
    }

    /// <summary>
    /// Spawns a plane object by passing enum value to SpawnButton function
    /// </summary>
    public void SpawnPlane()
    {
        SpawnButton(GameObjects.Plane);
    }

    /// <summary>
    /// Spawns a quad object by passing enum value to SpawnButton function
    /// </summary>
    public void SpawnQuad()
    {
        SpawnButton(GameObjects.Quad);
    }

    /// <summary>
    /// Spawns a sphere object by passing enum value to SpawnButton function
    /// </summary>
     public void SpawnSphere()
     {
        SpawnButton(GameObjects.Sphere);
     }

    

    /// <summary>
    /// This method is called by the Delete button inside Transform panel.
    /// It removes the currently selected object from the scene.
    /// </summary>
    public void RemoveButton()
    {
       if(!selectionManager.Selected)
        {
            return;
        }
       GameComponents gameObjectActive = selectionManager.CurrentSelected;
        objectSpawner.RemoveComponent(gameObjectActive.GameObjectType, gameObjectActive.gameObject);
    }

    /// <summary>
    /// This function is called by the Input Fields on if any of them value is changed.
    /// The function parses the value from string to float and save in three variables x,y and z.
    /// Which are then passed to the selected gameobjects ObjectPosition property to update its position in the scene.
    /// </summary>
    public void OnPositionInputChanged()
    {
        if (!selectionManager.Selected) return;

        bool xOk = float.TryParse(objectXPosition.text, out float x);
        bool yOk = float.TryParse(objectYPosition.text, out float y);
        bool zOk = float.TryParse(objectZPosition.text, out float z);

        if (!xOk || !yOk || !zOk) return;

        GameComponents gameObject = selectionManager.CurrentSelected;
        gameObject.ObjectPosition =
            new Vector3(x, y, z);
    }

    /// <summary>
    /// This function is called inside Selection Manager when an object is selected.
    /// It displays the Transform panel and initializes the values.
    /// </summary>
    public void ShowTransform()
    {
        TransformPanel.SetActive(true);
        GameComponents gameComponent = selectionManager.CurrentSelected;
        if (gameComponent == null)
        {
            return;
        }
        objectPosition = gameComponent.transform.position;

        objectXPosition.text = objectPosition.x.ToString();
        objectYPosition.text = objectPosition.y.ToString();
        objectZPosition.text = objectPosition.z.ToString();

    }

    /// <summary>
    /// This function is used to set deactivate the Transform panel.
    /// This function is also called inside Selection Manager script when an object is deselected.
    /// </summary>
    public void HideTransform()
    {
        TransformPanel.SetActive(false);

    }
    #endregion

    #region Private Methods
    /// <summary>
    /// This is our main function for spawning objects.
    /// This is the function called by every other gameobject specific spawn function.
    /// This function calls the ObjectSpawner's SpawnObject method to spawn the object at the origin position.
    /// And also saves the object type inside the GameComponents script attached to the spawned object.
    /// </summary>
    /// <param name="gameObjectType"></param>
    private void SpawnButton(GameObjects gameObjectType)
    {
        GameObject spawnedObject = objectSpawner.SpawnObject(gameObjectType, Origin);
        spawnedObject.GetComponent<GameComponents>().GameObjectType = gameObjectType;
    }

   
    #endregion
}
