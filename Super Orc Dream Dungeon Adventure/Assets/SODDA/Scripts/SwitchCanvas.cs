﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchCanvas : MonoBehaviour
{
    public GameObject OffCanvas;
    public GameObject OnCanvas;
    public GameObject FirstObject;

    public void Switch()
    {
        OffCanvas.SetActive(true);
        OnCanvas.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(FirstObject, null);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
