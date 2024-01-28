using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    GameObject go;
    
    private void Start()
    {

        StartCoroutine(spawn());
 
    }
  private IEnumerator spawn()
    {
       yield return new WaitForEndOfFrame();
        spawnobj(go);
    }

    private void spawnobj(GameObject go)
    {
        if (go != null)
        {
             GameObject instanceGo = Instantiate(go);
           instanceGo.transform.position = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("The GameObject is null");
        }
    }
    
}
