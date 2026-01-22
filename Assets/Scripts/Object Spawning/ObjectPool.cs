using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script creates a dynamic object pool for GameObjects in Unity. It creates different pool for different gameobject.
/// </summary>
public class ObjectPool
{
    #region Fields
    private List<GameObject> pool = new List<GameObject>();
    private GameObject prefab;
    #endregion

    #region Constructor
    /// <summary>
    /// Creates object pool for the given prefab. Makes dynamic object pooling possible.
    /// </summary>
    /// <param name="prefab">Type of GameObject for creating its pool</param>
    public ObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// This method returns an inactive GameObject from the pool if available, otherwise it 
    /// instantiates a new one, adds it to the pool, and returns it.
    /// </summary>
    public GameObject GetComponent()
    {
        for(int i =0; i<pool.Count; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        GameObject obj = GameObject.Instantiate<GameObject>(prefab);
        pool.Add(obj);
        return obj;
    }
    /// <summary>
    /// This method removes the object from scene by deactivating it, making it available for future reuse.
    /// </summary>
    /// <param name="gameObject">GameObject that has to be removed from the screen</param>
    public void ReturnComponent(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    #endregion
}
