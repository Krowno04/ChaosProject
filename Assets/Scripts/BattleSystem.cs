using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum BattleState { START, IOTURN, CLOVERTURN, NIKOLATURN, HARPERTURN, VINCETURN, SUPPORTTURN, ENEMY1TURN, ENEMY2TURN, ENEMY3TURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{

    public GameObject ioPrefab;
    public GameObject cloverPrefab;
    public GameObject nikolaPrefab;
    public GameObject harperPrefab;
    public GameObject vincePrefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    public Transform enemy1BattleStation;
    public Transform enemy2BattleStation;
    public Transform enemy3BattleStation;

    public Transform player1BattleStation;
    public Transform player2BattleStation;
    public Transform player3BattleStation;
    public Transform player4BattleStation;
    public Transform player5BattleStation;

    public BattleState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.START;
        SetUpBattle();
    }

    private void SetUpBattle()
    {
        Instantiate(ioPrefab, player1BattleStation);
        Instantiate(cloverPrefab, player2BattleStation);
        Instantiate(nikolaPrefab, player3BattleStation);
        Instantiate(harperPrefab, player4BattleStation);
        Instantiate(vincePrefab, player5BattleStation);

        Instantiate(enemy1Prefab, enemy1BattleStation);
        Instantiate(enemy2Prefab, enemy2BattleStation);
        Instantiate(enemy3Prefab, enemy3BattleStation);

    }
}
