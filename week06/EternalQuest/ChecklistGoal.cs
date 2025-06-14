public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, int points, int targetCount, int bonus)
        : base(name, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            return _points + (_currentCount == _targetCount ? _bonus : 0);
        }
        return 0;
    }

    public override string GetStatus() => $"[{(_currentCount >= _targetCount ? "X" : " ")}] {_name} -- Completed {_currentCount}/{_targetCount}";

    public override string Serialize() => $"ChecklistGoal|{_name}|{_points}|{_targetCount}|{_currentCount}|{_bonus}";
}
