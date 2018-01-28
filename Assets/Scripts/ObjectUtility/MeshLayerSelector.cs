using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshLayerSelector : MonoBehaviour {

    public string layerName;
    public int sortingOrder;

    private void Awake() {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.sortingLayerName = layerName;
        renderer.sortingOrder = sortingOrder;
    }
}
