using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FunkyCode;

public class PortalVisual : DoorVFX
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Light2D portalLight;
    [SerializeField] private Sprite openSprite;
    [SerializeField] private Sprite closedSprite;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float lightDimnessWhenClosed = 0.4f;

    void Start() {
        PlayClose();
    }
    public override void PlayOpen() {
        particleSystem.Play();
        particles.Play();
        portalLight.color.a = 1f;
        sr.sprite = openSprite;
    }
    public override void PlayClose() {
        particleSystem.Stop();
        particles.Stop();
        sr.sprite = closedSprite;
        portalLight.color.a = lightDimnessWhenClosed;
    }
}
