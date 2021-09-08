using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateABBF : StateABBF {

    public ChaseStateABBF(ABunchOfBoxesOnTheFloorSC stateController) : base(stateController) { }

    public override void CheckTransitions()
    {
        if (!stateController.CheckIfInRange("Player"))
        {
            if (Random.value > 0.5)
            {
                stateController.SetState(new ChonkStateABBF(stateController));
            }
            else
            {
                stateController.SetState(new WanderStateABBF(stateController));
            }
                
        }
    }
    public override void Act()
    {
        if(stateController.enemyToChase != null)
        {
            stateController.destination = stateController.enemyToChase.transform;
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        stateController.ChangeColor(Color.red);
        stateController.ai.agent.speed = .5f;
    }
}
