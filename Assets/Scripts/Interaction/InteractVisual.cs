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
    public bool isHighlighted = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        DefaultMaterial = sr.material;
        NormalSprite();
    }
    public void HighlightSprite() {
        isHighlighted = true;
        sr.material = HighlightedMaterial;
    }
    public void NormalSprite() {
        isHighlighted = false;
        sr.material = DefaultMaterial;
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerMovement>())
        HighlightSprite();
    }
    public void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerMovement>())
        NormalSprite();
    }

}
