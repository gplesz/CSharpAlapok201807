namespace _01ObserverPattern
{
    /// <summary>
    /// Definiáljuk az Observer "tudását":
    /// rendelkeznie kell egy függvénnyel, ahol értesíteni lehet
    /// 
    /// Ahhoz, hogy a paraméterek változása esetén ne kelljen változtatást a
    /// függvény szignatúráján elvégezni, a paramétereket bezárom egy osztálypéldányba
    /// 
    /// DTO: Data Transfer Object
    /// https://martinfowler.com/eaaCatalog/dataTransferObject.html
    /// </summary>
    public interface INotifiable
    {
        void Message(IMessage data);
    }
}