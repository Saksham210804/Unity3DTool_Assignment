using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Gives all the necessary information about a game object.
/// </summary>
public class GameComponents : MonoBehaviour
{
    #region Fields
    private Material material;
    private Vector3 objectPosition;
    private GameObjects gameObjectType;
    #endregion

    #region Properties
    /// <summary>
    /// Returns or sets the position of the object in the world.
    /// </summary>
    public Vector3 ObjectPosition
    {
        get { return objectPosition; }
        set { transform.position = value; 
        objectPosition = value;}
    }

    /// <summary>
    /// Returns or sets the type of the game object.
    /// </summary>
    public GameObjects GameObjectType
    {
        get { return gameObjectType; }
        set { gameObjectType = value; }
    }
    #endregion

    #region Unity Methods
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material; 
        objectPosition = transform.position;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Handles the color change when the object is selected. Called inside the Selection Manager clas.
    /// </summary>
    public void Select()
    {
        material.color = Color.blue;
    }
    /// <summary>
    /// Handles the color change when the object is deselected. Called inside the Selection Manager class.
    /// </summary>
    public void Deselect()
    {
        material.color = Color.white;
    }

  
    #endregion
}
