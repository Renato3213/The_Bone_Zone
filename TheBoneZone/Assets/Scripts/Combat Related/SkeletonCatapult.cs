using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonCatapult : CombatUnit, ICombatObserver
{
    public ParticleSystem walkParticles;


    private void Awake()
    {
        Initialize();
        baseRadius = agent.radius;
        CombatStartObserver.instance.unitList.Add(this);
        CombatManager.instance.blueTeam.Add(this);
        this.OpositeTeam = CombatManager.instance.redTeam;
    }

    void Start()
    {
        OccupyTiles();
    }

    void Update()
    {
        if (stateMachine.currentState == moveWithinRange)
        {
            walkParticles.Play();
        }
        else
        {
            walkParticles.Stop();
        }
    }


    void OccupyTiles()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1);

        List<TableTile> tiles = new List<TableTile>();


        foreach (Collider col in hitColliders)
        {
            TableTile tileToAdd;
            if (col.gameObject.TryGetComponent<TableTile>(out tileToAdd))
            {
                tiles.Add(tileToAdd);
            }
        }
        Debug.Log(tiles.Count);

        foreach (TableTile tile in tiles)
        {
            tile.placeable = false;
        }
    }

    public override void TakeDamage(int amount)
    {
        this.health -= amount;

        if (health <= 0) Die();
    }

    public override void Die()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.blueTeam.Remove(this);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject, 2f);
    }


    public void NotifyStart()
    {

    }

    private void OnDestroy()
    {
        CombatStartObserver.instance.unitList.Remove(this);
        CombatManager.instance.blueTeam.Remove(this);
    }
}

