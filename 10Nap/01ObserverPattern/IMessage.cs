namespace _01ObserverPattern
{
    /// <summary>
    /// Definiáljuk az Observer "tudását":
    /// rendelkeznie kell egy függvénnyel, ahol értesíteni lehet
    /// </summary>
    public interface IMessage
    {
        void Message(int data);
    }
}