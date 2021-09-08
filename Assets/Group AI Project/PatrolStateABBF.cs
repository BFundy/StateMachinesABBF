using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolStateABBF : StateABBF {


    public PatrolStateABBF(ABunchOfBoxesOnTheFloorSC stateController) : base(stateController) { }
   
    public override void CheckTransitions()
    {
        if (stateController.CheckIfInRange("Player"))
        {
            if (Random.value > 0.5)
            {
                stateController.SetState(new ChonkStateABBF(stateController));
            }
            else
            {
                stateController.SetState(new ChaseStateABBF(stateController));
            }
                      
        }
        
        
    }
    public override void Act()
    {
        if(stateController.destination == null || stateController.ai.DestinationReached())
        {
            stateController.destination = stateController.GetNextNavPoint();
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        stateController.destination = stateController.GetNextNavPoint();
        if (stateController.ai.agent != null)
        {
            stateController.ai.agent.speed = 1f;
        }
        stateController.ai.SetTarget(stateController.destination);
        stateController.ChangeColor(Color.blue);
    }

}
