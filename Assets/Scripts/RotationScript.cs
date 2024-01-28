using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    //public GameObject Product;
    public Vector3 RotationVector = new Vector3(0,50,0);
    private void Update()
    {
        this.gameObject.transform.Rotate(RotationVector * Time.deltaTime);
    }
}

