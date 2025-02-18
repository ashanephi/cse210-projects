public abstract class Activity
{
    private DateTime _Date;
    private int _Minutes;

    public DateTime GetDate()
    {
        return _Date;
    }

    public void SetDate(DateTime date)
    {
        _Date = date;
    }

    public int GetMinutes()
    {
        return _Minutes;
    }

    public void SetMinutes(int minutes)
    {
        _Minutes = minutes;
    }

    public Activity(DateTime date, int minutes)
    {
        _Date = date;
        _Minutes = minutes;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();
    public abstract double GetPace(); 

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();
        
        return $"{GetDate():dd MMM yyyy} {GetType().Name} ({GetMinutes()} min) - " +
               $"Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F2} min per mile";
    }
}