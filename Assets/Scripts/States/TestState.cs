using UnityEngine;

public class TestState : IState
{
    public void Setup()
    {
        Debug.Log("TestState Fist Method. Setup();");
    }

    public void Execute()
    {
        Debug.Log("TestState Continous Method. Execute();");
    }

    public void Exit()
    {
        Debug.Log("TestState Final Method. Exit();");
    }
}