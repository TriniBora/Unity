using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager obj;

    public GameObject pop;

    void Awake()
    {
        obj = this;
    }

    public void showPop(Vector3 pos)
    {
        pop.gameObject.GetComponent<Pop>().show(pos); // accedemos al objeto pop mediante el componente pop que es el script Pop
    }

    void OnDestroy()
    {
        obj = null;
    }

}
