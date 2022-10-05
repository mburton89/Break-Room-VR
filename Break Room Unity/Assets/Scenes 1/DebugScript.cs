using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowNullMeshFilters();
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void ShowNullMeshFilters()
    {
        var res = GameObject.FindObjectsOfType<MeshFilter>();
        //dreaded Do not use ReadObjectThreaded on scene objects!
        foreach (var nmo in res)
        {
            if (nmo.sharedMesh == null)
            {
                Debug.LogError("null meshfilter in " + nmo.transform.name, nmo.gameObject);
                Transform t = nmo.transform;
                GameObject.DestroyImmediate(t.GetComponent<MeshRenderer>());
                GameObject.DestroyImmediate(nmo);
            }
        }

        res = null;
    }
}
