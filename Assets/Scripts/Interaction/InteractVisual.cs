using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InteractVisual : MonoBehaviour
{
    private SpriteRenderer sr;
    [HideInInspector] public Material DefaultMaterial { get; set; }
    [field: SerializeField] public Material HighlightedMaterial { get; private set; }

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        DefaultMaterial = sr.material;
        NormalSprite();
    }
    public void HighlightSprite() {
        sr.material = HighlightedMaterial;
    }
    public void NormalSprite() {
        sr.material = DefaultMaterial;
    }
}
