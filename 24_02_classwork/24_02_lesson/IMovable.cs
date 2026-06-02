namespace _24_02_lesson;

public interface IMovable
{
    string Brand { get; }
    string Model { get; }
    double Velocity { get; }
    void SpeedUp(double speed);
    void SlowDown(double speed);
}