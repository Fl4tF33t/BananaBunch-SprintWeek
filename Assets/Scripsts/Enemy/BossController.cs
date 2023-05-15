using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BossController : MonoBehaviour
{
    public PathCreator[] pathCreator;

    //Movement Variables
    [SerializeField]
    int pathIndex;
    [SerializeField]
    private float bossMovementSpeed = 5;
    private float distanceTravelled;
    private bool isMoving;

    //AttackVariables
    [SerializeField]
    private float stingerAttackRate = 30f;
    [SerializeField]
    private GameObject stingerPrefab;
    [SerializeField]
    private float stingerSpeed = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        isMoving = true;
        InvokeRepeating("StingerAttack", 2, stingerAttackRate);
        Debug.Log(pathCreator[1].path.GetPoint(56));
    }

    // Update is called once per frame
    void Update()
    {
        Movement(pathIndex);
    }

    private void Movement(int index)
    {
        if (isMoving)
        {
            distanceTravelled += bossMovementSpeed * Time.deltaTime;
            transform.position = pathCreator[index].path.GetPointAtDistance(distanceTravelled);
            //transform.rotation = pathCreator[index].path.GetRotationAtDistance(distanceTravelled);
        }
    }
    private void StingerAttack() //uses a tag system, the players need to have a player tag
    {
        //stops the movement
        StartCoroutine(AttackStart(2f));

        //Finds all the players and a random location
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int randomIndex = Random.Range(0, players.Length);
        Vector3 myPos = transform.position;
        Vector3 playerPos = players[randomIndex].transform.position;
        Vector3 direction = playerPos - myPos;

        //shoot a projectile at that enemy
        GameObject newStinger = Instantiate(stingerPrefab, myPos, Quaternion.identity);
        Rigidbody stingerRB = newStinger.GetComponent<Rigidbody>();
        stingerRB.AddForce(direction * stingerSpeed);

    }
    private IEnumerator AttackStart(float timeDelay)
    {
        isMoving = !isMoving;
        yield return new WaitForSeconds(timeDelay);
        print("waiting");
        isMoving = !isMoving;
    }


}
