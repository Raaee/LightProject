using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainVisual : MonoBehaviour
{
    [SerializeField] private Sprite horizontalSprite;
    [SerializeField] private Sprite verticalSprite;

    private SpriteRenderer sr;
    private float horizontalSpriteYoffset = -0.6f;
    private float verticalSpriteYoffset = 0.33f;
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    public void HorizontalSprite() {
        sr.sprite = horizontalSprite;
        transform.localPosition = new Vector3(0,horizontalSpriteYoffset,0);
    }
    public void VerticalSprite() {
        sr.sprite = verticalSprite;
        transform.localPosition = new Vector3(0, -verticalSpriteYoffset, 0);
    }

}
