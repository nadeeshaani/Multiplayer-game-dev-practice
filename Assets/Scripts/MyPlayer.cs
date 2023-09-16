using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MyPlayer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private float speed;
    [SerializeField] private PhotonView photonView;

    private bool canMovePlayer;
    private Vector3 playerDirection;


    #endregion


    #region UNITY CALLBACKS
    private void Awake()
    {
        canMovePlayer = false;
    }

    #endregion




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerDirection = Vector3.up;
                canMovePlayer = true;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerDirection = Vector3.down;
                canMovePlayer = true;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerDirection = Vector3.left;
                canMovePlayer = true;
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerDirection = Vector3.right;
                canMovePlayer = true;
            }

            else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                canMovePlayer = false;
            }

            if (canMovePlayer)
            {
                transform.Translate(playerDirection * Time.deltaTime * speed);
            }
        }


    }
}
