using UnityEngine;

public class NPCStateMachine : MonoBehaviour
{
	public enum NPCState{
		Idle,
		Walk,
		Dialogue,
		Filp
	}

	public NPCState CurrentState {
		get;
		private set;
	}

	public NPCStateMachine(NPCState initialState = NPCState.Idle){
		CurrentState = initialState;
	}

    public void ChangeState(NPCState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
		}
	}
}
