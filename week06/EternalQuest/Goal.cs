public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();
    public abstract void DisplayProgress();

    public bool IsComplete => _isComplete;
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;
}