using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BossMovement : MonoBehaviour
{
    //this script is for the movement of the Boss

    //Movement Variables
    [SerializeField]
    PathCreator[] pathCreator;
    public int pathIndex;
    [SerializeField]
    private float bossMovementSpeed = 5;
    private float distanceTravelled;

    public bool isMovingOnPath;
    [SerializeField]
    private float timerToDropSpot;
    [SerializeField]
    private float timerToStageSpot;
    [SerializeField]
    float resetTimerToDropSpot;
    [SerializeField]
    float resetTimerToStageSpot;
    [SerializeField]
    Transform dropPosition;
    [SerializeField]
    Transform stagePosition;
    [SerializeField]
    float speedToDropPosition = 5f;
    [SerializeField]
    float speedToStagePosition = 5f;

    private void Update()
    {
        PathMovement(pathIndex);
        StartSmashing();
    }

    private void PathMovement(int index)
    {
        if (isMovingOnPath)
        {
            distanceTravelled += bossMovementSpeed * Time.deltaTime;
            transform.position = pathCreator[index].path.GetPointAtDistance(distanceTravelled);
        }
    }

    private void StartSmashing()
    {
        if(isMovingOnPath == false)
        {
            transform.position = Vector3.Lerp(transform.position, dropPosition.transform.position, speedToDropPosition * Time.deltaTime);
            timerToDropSpot -= Time.deltaTime;
            if (timerToDropSpot < 0)
            {
                timerToStageSpot -= Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, stagePosition.transform.position, speedToStagePosition * Time.deltaTime);
                if(timerToStageSpot < 0)
                {
                    isMovingOnPath = true;
                    timerToDropSpot = resetTimerToDropSpot;
                    timerToStageSpot = resetTimerToStageSpot;
                }
            }
        }
    }

}
