using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarVisual : MonoBehaviour
{
    private SpriteRenderer sr;
    public List<Sprite> pillarRotationSprites;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        ChangeSpriteRotation(0);
    }
    public void ChangeSpriteRotation(int index) {
        sr.sprite = pillarRotationSprites[index];
    }
    
}
