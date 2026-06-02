namespace _24_02_lesson;

public class Task1
{
    public struct Car : IMovable
    {
        private double _velocity;
        private string _brand;
        private string _model;
        
        public double Velocity { get {return _velocity; } }
        public string Brand => _brand;
        public string Model => _model;

        public Car(string brand, string model)
        {
            _velocity = 0;
            _brand = brand;
            _model = model;
        }

        public void SpeedUp(double speed)
        {
            _velocity += speed;
        }

        public void SlowDown(double speed)
        {
            _velocity -= speed;
        }
    }
}