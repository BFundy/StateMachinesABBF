using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateABBF {

    protected ABunchOfBoxesOnTheFloorSC stateController;
    //constructor
    public StateABBF(ABunchOfBoxesOnTheFloorSC stateController)
    {
        this.stateController = stateController;
    }
    public abstract void CheckTransitions();

    public abstract void Act();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }



	
}
