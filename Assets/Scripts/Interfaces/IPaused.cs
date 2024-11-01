public interface IPaused
{
    bool IsPaused { get; set; }

    void Pause();

    void Resume();
}
