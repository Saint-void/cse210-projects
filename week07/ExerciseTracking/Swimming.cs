public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int durationMinutes, int laps) 
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50) / 1000 * 0.62; // miles
    public override double GetSpeed() => (GetDistance() / DurationMinutes) * 60;
    public override double GetPace() => DurationMinutes / GetDistance();
}