public interface IState
{
    void Setup();
    void Execute();
    void Exit();
}