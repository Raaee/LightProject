using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockVisual : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private GameObject lockLight;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer symbol_SR;
    [SerializeField] private Sprite lockedSprite;
    [SerializeField] private Sprite unlockedSprite;
    [SerializeField] private Sprite symbolLockedSprite;
    [SerializeField] private Sprite symbolUnlockedSprite;
    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        LockSprite();
    }
    public void LockSprite() {
        sr.sprite = lockedSprite;
        symbol_SR.sprite = symbolLockedSprite;
        lockLight.SetActive(false);
    }
    public void UnlockSprite() {
        sr.sprite = unlockedSprite;
        symbol_SR.sprite = symbolUnlockedSprite;
        lockLight.SetActive(true);
    }
}
