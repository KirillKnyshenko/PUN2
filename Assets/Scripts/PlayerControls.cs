using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (!_photonView.IsMine)
        {
            return;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Time.deltaTime * 5f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Time.deltaTime * 5f, 0f, 0f);
        }
    }
}
