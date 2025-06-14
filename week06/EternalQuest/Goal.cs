public abstract class Goal
{
    protected string _name;
    protected int _points;

    public Goal(string name, int points)
    {
        _name = name;
        _points = points;
    }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string Serialize();
}
