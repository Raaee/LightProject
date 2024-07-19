using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSaveProgress : MonoBehaviour
{
   
    void Start()
    {
        Debug.Log("You reached the end of gameplay. Resetting your save progress back to 0");
        ES3.Save(Utility.CURRENT_LEVEL_KEY, 0);
    }

    
}
