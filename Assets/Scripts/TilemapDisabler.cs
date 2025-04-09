using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GetComponent<TilemapDisabler>().enabled =false;
    }
}
