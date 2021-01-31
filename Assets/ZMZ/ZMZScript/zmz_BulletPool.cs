using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmz_BulletPool : UnitySingle<zmz_BulletPool>
{
    private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>>();

    public GameObject CreateObject(string pKey, GameObject pGameObject, Transform pParent, Vector3 plocalPosition,
                                    Quaternion localRotation, string pGameObjectName)
    {
        GameObject tempGameObject = FindUseable(pKey);
        if (tempGameObject != null)
        {
            tempGameObject.SetActive(true);
        }
        else
        {
            tempGameObject = Instantiate(pGameObject, Vector3.zero, Quaternion.identity) as GameObject;
            Add(pKey, tempGameObject);
        }
        tempGameObject.transform.parent = pParent;
        tempGameObject.transform.localPosition = plocalPosition;
        tempGameObject.transform.localRotation = localRotation;
        tempGameObject.name = pGameObjectName;
        return null;
    }
    public void CollectObject(GameObject pGo)
    {
        pGo.transform.parent = null;
        pGo.SetActive(false);
    }

    private GameObject FindUseable(string pKey)
    {
        if (cache.ContainsKey(pKey))
        {
            return cache[pKey].Find(p => !p.activeSelf);
        }
        return null;
    }
    private void Add(string pKey, GameObject pGo)
    {
        if (!cache.ContainsKey(pKey))
        {
            cache.Add(pKey, new List<GameObject>());
        }
        cache[pKey].Add(pGo);
    }
}
