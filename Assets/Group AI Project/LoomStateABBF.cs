using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoomStateABBF : StateABBF
{
    public LoomStateABBF(ABunchOfBoxesOnTheFloorSC stateController) : base(stateController) { }

    float timeLimit;
    float timer;
    public override void CheckTransitions()
    {
        if (stateController.CheckIfInRange("Player"))
        {
            stateController.SetState(new ChaseStateABBF(stateController));
        }
        if (timer > timeLimit)
        {
            stateController.SetState(new MakeNavPointsABBF(stateController));
            //stateController.SetState(new LoomStateABBF(stateController));
        }
    }
    public override void Act()
    {
        //throw new System.NotImplementedException();
        timer += Time.deltaTime;
        Debug.Log("Eyyyy Macerana EIIII!");
    }

    

  public override void OnStateEnter()
    {
        timer = 0f;
        timeLimit = 5f;
        stateController.ChangeColor(Color.yellow);
        stateController.ai.agent.speed = 0f;
        //stateController.ai.agent.ResetPath();
    }
}
