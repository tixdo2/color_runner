namespace Input
{
    public interface IPlayerInput
    {
        
        PlayerInputActions Actions { get; }
        float GetHorizontalAxis();

        void Enable();

        void Disable();
    }
}