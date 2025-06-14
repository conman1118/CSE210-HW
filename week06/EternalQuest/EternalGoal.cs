public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) {}

    public override bool IsComplete() => false;

    public override int RecordEvent() => _points;

    public override string GetStatus() => $"[ ] {_name} (Eternal)";

    public override string Serialize() => $"EternalGoal|{_name}|{_points}";
}
