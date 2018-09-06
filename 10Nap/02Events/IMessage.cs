namespace _01ObserverPattern
{
    /// <summary>
    /// Tartalmazza mindazt, amit a 
    /// megfigyelt osztály magáról szeretne
    /// megosztani a megfigyelőkkel
    /// </summary>
    public interface IMessage
    {
        int Data { get; set; }
        string Text { get; set; }
    }
}