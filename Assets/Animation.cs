using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour

{

    #region VARIABLES

    [SerializeField] private Transform cube;
    [SerializeField] private float bumpSpeed;
    [SerializeField] private int bumpEndTicks;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int moveEndTicks;
    [SerializeField] private Vector3 moveDirection;

    private Vector3 cubeInitPos;

    private int ticks;
    private float stepFactor;
    private bool isCubeInBumpAnimation;
    private bool isCubeInMoveAnimation;

    #endregion


    #region UNITY CALLBACKS
    void Start()
    {
        cubeInitPos = cube.localPosition;
        
    }



    private void FixedUpdate()
    {
       BumpAnimation();
       MoveAnimation();
    }
    #endregion

    #region BUMP
    public void StartBumpAnimation()
    {
        cube.localPosition = cubeInitPos;

        stepFactor = 1f / bumpEndTicks;

        ticks = 0;
        isCubeInBumpAnimation = true;
    }

    public void BumpAnimation()
    {
        if (!isCubeInBumpAnimation) return;

        if (ticks == bumpEndTicks)
        {
            cube.localPosition = cubeInitPos;
            isCubeInBumpAnimation = false;
        }

        else
        {
            ticks++;
            ticks = ticks > bumpEndTicks ? bumpEndTicks : ticks;

            float steps = ticks * stepFactor;
            steps = 4 * steps - 4 * steps * steps;

            cube.localPosition = cubeInitPos + steps * Vector3.up * bumpSpeed;


        }
    }

    #endregion

    #region MOVE
    public void MoveCube()
    {
        cube.localPosition = cubeInitPos;

        stepFactor = 1f / moveEndTicks;

        ticks = 0;
        isCubeInMoveAnimation = true;
    }

    private void MoveAnimation()
    {
        if (!isCubeInMoveAnimation) return;

        if (ticks == moveEndTicks)
        {
            cube.position = cubeInitPos + moveDirection * moveSpeed;
            isCubeInMoveAnimation = false;
        }
        else
        {
            ticks++;
            ticks = ticks > moveEndTicks ? moveEndTicks : ticks;

            float steps = ticks * stepFactor;
            steps = 3 * steps * steps - 2 * steps * steps * steps;

            cube.position = cubeInitPos + steps * moveDirection * moveSpeed;

        }
    }

    #endregion







}
