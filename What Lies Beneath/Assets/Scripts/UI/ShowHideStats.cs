using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideStats : MonoBehaviour
{
    public GameObject statScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            statScreen.SetActive(!statScreen.activeSelf);
        }
    }
}
