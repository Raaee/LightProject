
using FMODUnity;
using UnityEngine;

public class LockKeyAudio : MonoBehaviour
{

    [SerializeField] private EventReference lockKeyPlacedSfx;
    [SerializeField] private KeyLock keyLock;


    private void Awake()
    {
        keyLock.OnKeyLockPlaced.AddListener(PlayLockKeyPlacedSfx);
    }

    public void PlayLockKeyPlacedSfx()
    {
        RuntimeManager.PlayOneShot(lockKeyPlacedSfx);
    }
}
