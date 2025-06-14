public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _completed = false;
    }

    public override bool IsComplete() => _completed;

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }

    public override string GetStatus() => $"[{"X"}] {_name}";

    public override string Serialize() => $"SimpleGoal|{_name}|{_points}|{_completed}";
}
