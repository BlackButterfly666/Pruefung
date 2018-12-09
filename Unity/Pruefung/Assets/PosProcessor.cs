using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PosProcessor : MonoBehaviour {
    [SerializeField] Material desaturationMaterial;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, desaturationMaterial);
    }
}
