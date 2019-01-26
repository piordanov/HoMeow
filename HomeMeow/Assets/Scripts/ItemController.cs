using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemController : MonoBehaviour
{
    protected Rigidbody rgb;

    public void Start() {
        rgb = GetComponent<Rigidbody> ();
        OnStart();
    }

    virtual public void OnStart() {

    }

    public bool isThrowable() {
        return true;
    }

}
