public class ChecklistGoal : Goal
{
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = 0;
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount) 
        : base(name, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
        _isComplete = (currentCount >= targetCount);
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                _isComplete = true;
                return _points + _bonusPoints;
            }
            return _points;
        }
        return 0;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_targetCount}|{_bonusPoints}|{_currentCount}";
    }

    public override void DisplayProgress()
    {
        Console.Write(_isComplete ? "[X] " : "[ ] ");
        Console.WriteLine($"{_name} ({_description}) -- Completed {_currentCount}/{_targetCount}");
    }
}