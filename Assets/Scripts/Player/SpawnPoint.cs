using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Start()
    {
        player.transform.position = this.gameObject.transform.position;
    }
}
