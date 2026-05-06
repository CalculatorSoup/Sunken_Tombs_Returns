using EntityStates;
using RoR2;
using RoR2.Networking;
using SunkenTombWorm.EntityStates.AcridCage;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

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
