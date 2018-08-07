namespace _02SikidomokTerulete
{
    public interface IPlane
    {
        //a public kolcsszóra nincs szükség, mert 
        //ami a felületen látszik az definíció szerint publikus
        double Area();

        //ha például a felület kér egy ilyen tulajdonságot,
        //ez közösen megoldható például egy abszrakt osztállyal
        //string Name { get; set; }
    }
}