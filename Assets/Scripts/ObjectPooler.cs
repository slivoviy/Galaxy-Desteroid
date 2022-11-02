using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem {
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand;

    public ObjectPoolItem(GameObject obj, int amt, bool exp = true) {
        objectToPool = obj;
        amountToPool = Mathf.Max(amt, 2);
        shouldExpand = exp;
    }
}

public class ObjectPooler : MonoBehaviour {
    public static ObjectPooler SharedInstance;
    [SerializeField] private List<ObjectPoolItem> itemsToPool;


    private List<List<GameObject>> _pooledObjectsList;
    private List<GameObject> _pooledObjects;
    private List<int> _positions;

    private void Awake() {
        SharedInstance = this;

        _pooledObjectsList = new List<List<GameObject>>();
        _pooledObjects = new List<GameObject>();
        _positions = new List<int>();


        for (var i = 0; i < itemsToPool.Count; i++) {
            ObjectPoolItemToPooledObject(i);
        }
    }


    public GameObject GetPooledObject(int index) {
        var curSize = _pooledObjectsList[index].Count;
        for (var i = _positions[index] + 1; i < _positions[index] + _pooledObjectsList[index].Count; i++) {
            if (_pooledObjectsList[index][i % curSize].activeInHierarchy) continue;
            
            _positions[index] = i % curSize;
            return _pooledObjectsList[index][i % curSize];
        }

        if (!itemsToPool[index].shouldExpand) return null;
        
        var obj = Instantiate(itemsToPool[index].objectToPool, transform, true);
        obj.SetActive(false);
        _pooledObjectsList[index].Add(obj);
        return obj;

    }

    public List<GameObject> GetAllPooledObjects(int index) {
        return _pooledObjectsList[index];
    }


    public int AddObject(GameObject go, int amt = 3, bool exp = true) {
        var item = new ObjectPoolItem(go, amt, exp);
        var currLen = itemsToPool.Count;
        itemsToPool.Add(item);
        ObjectPoolItemToPooledObject(currLen);
        return currLen;
    }


    private void ObjectPoolItemToPooledObject(int index) {
        var item = itemsToPool[index];

        _pooledObjects = new List<GameObject>();
        for (var i = 0; i < item.amountToPool; i++) {
            var obj = Instantiate(item.objectToPool, transform, true);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }

        _pooledObjectsList.Add(_pooledObjects);
        _positions.Add(0);
    }
}