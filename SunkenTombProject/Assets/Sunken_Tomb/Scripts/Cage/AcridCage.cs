using EnemiesReturns.Enemies.MechanicalSpider.Drone;
using EntityStates;
using RoR2;
using RoR2.Networking;
using SunkenTombWorm.EntityStates.AcridCage;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using SunkenTombWorm;

public class AcridCage : NetworkBehaviour
{
    [SyncVar]
    private bool opened;

    public SerializableEntityStateType openState = new SerializableEntityStateType(typeof(Open));
    public SerializableEntityStateType closedState = new SerializableEntityStateType(typeof(Closed));


    //boolean that tracks whether this is opened network style
    public bool Networkopened
    {
        get
        {
            return opened;
        }
        [param: In]
        set
        {
            SetSyncVar(value, ref opened, 1u);
        }
    }

    public override int GetNetworkChannel()
    {
        return QosChannelIndex.defaultReliable.intVal;
    }

    //get whether this should be interactable depending on whether it is open or not
    public Interactability GetInteractability(Interactor activator)
    {
        if (opened)
        {
            return Interactability.Disabled;
        }
        return Interactability.Available;
    }

    ChestBehavior cb;
    ScriptedCombatEncounter[] encounters;
    //Starts the Acrid boss encounter. Also checks the ChestBehavior's drop count to spawn more Acrids if you used a Sale Star on the cage
    [Server]
    public async void SpawnAcrid()
    {
        cb = gameObject.GetComponent<ChestBehavior>();

        Transform encounterHolder = gameObject.transform.GetChild(3);

        encounters = encounterHolder.GetComponentsInChildren<ScriptedCombatEncounter>(); //scary

        for (int i = 0; i < cb.dropCount; i++)
        {
            if (encounters[i])
            {
                encounters[i].BeginEncounter();
            }
            await Task.Delay(5000);
        }

    }


    [Server]
    public void Open()
    {
        if (!NetworkServer.active)
        {
            return;
        } else
        {
            EntityStateMachine esm = gameObject.GetComponent<EntityStateMachine>();
            if (esm)
            {
                esm.SetNextState(EntityStateCatalog.InstantiateState(ref openState));
            }
        }
    }

    public void OnEnable()
    {
        InstanceTracker.Add(this);
    }
    public void OnDisable()
    {
        InstanceTracker.Remove(this);
    }
}
