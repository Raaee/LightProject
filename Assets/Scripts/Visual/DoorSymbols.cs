using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorSymbols : MonoBehaviour
{
    [SerializeField] private DoorLogic doorLogic;
    //public List<ILock> locks;
    [SerializeField] private GameObject SymbolPrefab;
    [SerializeField] private Sprite lockCircleSprite;
    [SerializeField] private Sprite lockTriangleSprite;
    [SerializeField] private Sprite lockSquareSprite;
    [SerializeField] private Sprite lockDiamondSprite;
    [SerializeField] private Sprite UnlockCircleSprite;
    [SerializeField] private Sprite UnlockTriangleSprite;
    [SerializeField] private Sprite UnlockSquareSprite;
    [SerializeField] private Sprite UnlockDiamondSprite;

    //Add Keys sprite

    public Dictionary<GameObject, GameObject> locks = new Dictionary<GameObject, GameObject>();

    private void Start()
    {
        doorLogic = GetComponentInParent<DoorLogic>();
        DisplayPortalSymbolUI();
        Init();
    }

    private void Init()
    {
        foreach (ILock alock in doorLogic.locks)
        {
            alock.OnInputDetection.AddListener(UpdateSymbols);
        }
    }

    public void DisplayPortalSymbolUI(){

        foreach (ILock door in doorLogic.locks) {
            LaserLock laserlock = door.gameObject.GetComponentInChildren<LaserLock>();
            if (laserlock == null) {
                return;
            }
            GameObject Geo = Instantiate(SymbolPrefab);
            Geo.gameObject.transform.parent = this.transform;

            locks.Add(door.gameObject, Geo);
            Image imageGeo = Geo.GetComponent<Image>();
            imageGeo.sprite = GetLockSpriteBaseOnType(laserlock.GetLaserKeys());
        }
    }

    private Sprite GetLockSpriteBaseOnType(LaserKeys keys) {
        switch (keys) {
            case LaserKeys.TRIANGLE_LASER:
                return lockTriangleSprite;
            case LaserKeys.CIRCLE_LASER:
                return lockCircleSprite;
            case LaserKeys.SQUARE_LASER:
                return lockSquareSprite;
            case LaserKeys.DIAMOND_LASER:
                return lockDiamondSprite;
            default:
                return null;
        }
    }

    private  Sprite GetUnlockSpriteBaseOnType(LaserKeys keys)
    {
        switch (keys)
        {
            case LaserKeys.TRIANGLE_LASER:
                return UnlockTriangleSprite;
            case LaserKeys.CIRCLE_LASER:
                return UnlockCircleSprite;
            case LaserKeys.SQUARE_LASER:
                return UnlockSquareSprite;
            case LaserKeys.DIAMOND_LASER:
                return UnlockDiamondSprite;
            default:
                return null;
        }
    }


    public void UpdateSymbols() {
        foreach (KeyValuePair<GameObject, GameObject> a_look in locks)
        {
            Image geo = a_look.Value.GetComponent<Image>();
            LaserLock laserlock = a_look.Key.GetComponentInChildren<LaserLock>();
            if (!a_look.Key.GetComponent<ILock>().IsLocked)
            {
                geo.sprite = GetUnlockSpriteBaseOnType(laserlock.GetLaserKeys());
            }
            else {
                geo.sprite = GetLockSpriteBaseOnType(laserlock.GetLaserKeys());
            }
        }
    }
}
