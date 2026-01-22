using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the spawning and removal of different GameObjects using object pool class.
/// This script uses dynamic object pooling to efficiently manage GameObject instances.
/// </summary>
public class ObjectSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject Capsule;
    [SerializeField] private GameObject Cube;
    [SerializeField] private GameObject Cylinder;
    [SerializeField] private GameObject Plane;
    [SerializeField] private GameObject Quad;
    [SerializeField] private GameObject Sphere;
    private ObjectPool objectPool;
    private Dictionary<GameObjects, ObjectPool> gameComponents = new Dictionary<GameObjects, ObjectPool>();
    #endregion

    #region Unity Methods

    /// <summary>
    /// Awake is used to Initialize the object pools for each GameObject type
    /// and store them in a dictionary for easy access.
    /// </summary>
    private void Awake()
    {
        gameComponents.Add(GameObjects.Capsule, new ObjectPool(Capsule));
        gameComponents.Add(GameObjects.Cube, new ObjectPool(Cube));
        gameComponents.Add(GameObjects.Cylinder, new ObjectPool(Cylinder));
        gameComponents.Add(GameObjects.Plane, new ObjectPool(Plane));
        gameComponents.Add(GameObjects.Quad, new ObjectPool(Quad));
        gameComponents.Add(GameObjects.Sphere, new ObjectPool(Sphere));
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// This method spawns a GameObject of the specified type at the given position.
    /// The GameObject is retrieved from the corresponding object pool by GetComponent method.
    /// This method calls GetComponent method which is the main method handling object pooling inside ObjectPool class.
    /// </summary>
    /// <param name="gameObjectType">An enumeration that maps object types to their corresponding 
    /// object pools for object spawning.</param>
    /// <param name="position">Instantiate the object at a specific position.</param>
    /// <returns></returns>
    public GameObject SpawnObject(GameObjects gameObjectType, Vector3 position)
    {
        objectPool = gameComponents[gameObjectType];
        GameObject obj = objectPool.GetComponent();
        obj.transform.position = position;
        obj.transform.rotation = Quaternion.identity;
        return obj;
        
    }
  
    /// <summary>
    /// Used to remove the GameObject from the scene and return it to the appropriate object pool using Return Component
    /// which deactivates the object for later use.
    /// </summary>
    /// <param name="gameObjectType"></param>
    /// <param name="gameObject"></param>
    public void RemoveComponent(GameObjects gameObjectType, GameObject gameObject)
    {
        objectPool = gameComponents[gameObjectType];
        objectPool.ReturnComponent(gameObject);
    }
    #endregion
}
