using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorSymbols : MonoBehaviour
{
    [SerializeField] private DoorLogic doorLogic;
    [SerializeField] private GameObject SymbolPrefab;
    [SerializeField] private float keyImageScale = 3f;
    [SerializeField] private float symbolImageScale = 2.5f;
    public Dictionary<GameObject, GameObject> locks = new Dictionary<GameObject, GameObject>();

    [Header("Circle")]
    [SerializeField] private Sprite lockedCircleSprite;
    [SerializeField] private Sprite unlockedCircleSprite;

    [Header("Triangle")]
    [SerializeField] private Sprite lockedTriangleSprite;
    [SerializeField] private Sprite unlockedTriangleSprite;

    [Header("Square")]
    [SerializeField] private Sprite lockedSquareSprite;
    [SerializeField] private Sprite unlockedSquareSprite;

    [Header("Diamond")]
    [SerializeField] private Sprite lockedDiamondSprite;
    [SerializeField] private Sprite unlockedDiamondSprite;

    [Header("Key")]
    [SerializeField] private Sprite lockedKeySprite;
    [SerializeField] private Sprite unlockedKeySprite;


    private void Start()
    {
        doorLogic = GetComponentInParent<DoorLogic>();
        Init();
        DisplayPortalSymbolUI();
    }

    private void Init()
    {
        foreach (ILock alock in doorLogic.locks)
        {
            alock.OnInputDetection.AddListener(UpdateSymbols);
        }
    }

    public void DisplayPortalSymbolUI(){
        foreach (ILock aLock in doorLogic.locks) {
            ILock ilock = aLock.gameObject.GetComponent<ILock>();
            if (ilock == null) {
                continue;
            }
            GameObject go = Instantiate(SymbolPrefab);
            go.gameObject.transform.SetParent(this.transform);

            Image image = go.GetComponent<Image>();
            if (aLock.gameObject.GetComponentInChildren<KeyLock>()) {
                image.transform.localScale = new Vector3(keyImageScale,keyImageScale,0);
            } else {
                image.transform.localScale = new Vector3(symbolImageScale,symbolImageScale, 0);
            }
            go.name = image.name + ilock.GetLaserKey();
            image.preserveAspect = true;
            image.sprite = GetLockedSpriteBaseOnType(ilock.GetLaserKey());
            locks.Add(aLock.gameObject, go);
        }
    }

    private Sprite GetLockedSpriteBaseOnType(LaserKeys keys) {
        return keys switch {
            LaserKeys.TRIANGLE_LASER => lockedTriangleSprite,
            LaserKeys.CIRCLE_LASER => lockedCircleSprite,
            LaserKeys.SQUARE_LASER => lockedSquareSprite,
            LaserKeys.DIAMOND_LASER => lockedDiamondSprite,
            LaserKeys.KEY => lockedKeySprite,
            _ => null,
        };
    }

    private  Sprite GetUnlockedSpriteBaseOnType(LaserKeys keys)
    {
        return keys switch {
            LaserKeys.TRIANGLE_LASER => unlockedTriangleSprite,
            LaserKeys.CIRCLE_LASER => unlockedCircleSprite,
            LaserKeys.SQUARE_LASER => unlockedSquareSprite,
            LaserKeys.DIAMOND_LASER => unlockedDiamondSprite,
            LaserKeys.KEY => unlockedKeySprite,
            _ => null,
        };
    }

    public void UpdateSymbols() {
        foreach (KeyValuePair<GameObject, GameObject> aLock in locks)
        {
            Image image = aLock.Value.GetComponent<Image>();
            ILock ilock = aLock.Key.GetComponentInChildren<ILock>();
            if (ilock.IsLocked)
            {
                image.sprite = GetLockedSpriteBaseOnType(ilock.GetLaserKey());
            }
            else {
                image.sprite = GetUnlockedSpriteBaseOnType(ilock.GetLaserKey());
            }
           
        }
    }
}
