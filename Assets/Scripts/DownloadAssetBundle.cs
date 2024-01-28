using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using Lean.Touch;

public class DownloadAssetBundle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DownloadAssetBundleFromURL());
    }
    private IEnumerator DownloadAssetBundleFromURL()
    {
        GameObject stylishproduct = null;
        string url = "https://drive.usercontent.google.com/u/0/uc?id=1ilJSZ0T2uvA2TMGl__LuJZuobypVLy4S&export=download";
        
        using(UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogWarning("Error on the get request at : " + url + " " + www.error);

            }
            else
            {
                AssetBundle bundles = DownloadHandlerAssetBundle.GetContent(www);
                stylishproduct = bundles.LoadAsset(bundles.GetAllAssetNames()[0]) as GameObject;
                bundles.Unload(false);
                yield return new WaitForEndOfFrame();
            }
            www.Dispose();
        }
        AssignGameObject(stylishproduct);
    }
    private void AssignGameObject(GameObject go)
    {
        if (go != null)
        {
            StateNameController.Product = go;
            GameObject instanceGo = Instantiate(go);
            instanceGo.AddComponent<RotationScript>();
            instanceGo.AddComponent<LeanTwistRotateAxis>();
            instanceGo.transform.position = Vector3.zero;
        }
        else
        {
            Debug.LogWarning("The GameObject is null");
        }
    }
}


