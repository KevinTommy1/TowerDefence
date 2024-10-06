using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //SerializeField - Allows Inspector to get access to private fields.
    //If we want to get access to this from another class, we'll just need to make public getters
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Transform[] wayPoints;
    [SerializeField]
    private float navigationUpdate;
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private int rewardAmount;

    private int target = 0;
    private Transform enemy;
    private Collider2D enemyCollider;
    private Animator anim;
    private float navigationTime = 0;
    private bool isDead = false;


    public bool IsDead
    {
        get { return isDead; }
    }

    private void Start()
    {
        enemy = GetComponent<Transform>();
        enemyCollider = GetComponent<Collider2D>();
        GameManager.Instance.RegisterEnemy(this);
    }
}