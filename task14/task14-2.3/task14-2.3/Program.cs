using task14_2._3;
using task14_2._3.add;
using System.Runtime.Serialization.Formatters.Binary;

using System.Runtime.Serialization;

try
{
    #region serialization
    Storage<Product> productStorage = new Storage<Product>();

    Dairy_products milk = new Dairy_products(new DateTime(15, 10, 15), "Milk", 100, 0.9);
    Dairy_products yogurt = new Dairy_products(new DateTime(2022, 6, 27), "Yogurt", 100, 0.9);
    Dairy_products ice = new Dairy_products(new DateTime(2022, 7, 2), "Ice-cream", 22, 0.08);
    Meat lamb = new Meat(Category.Highest, MeatType.Lamb, "Steak", 100, 50);
    Product p1 = new Product("Sandwich", 40, 0.05);
    productStorage.Add(milk);
    productStorage.Add(yogurt);
    productStorage.Add(ice);
    productStorage.Add(ice);
    productStorage.Add(p1);
    productStorage.Add(lamb);

    Serializer serializer = new Serializer();
    serializer.SerializeItem(productStorage);
    Check.Output(serializer.DeserializeItem());
    #endregion serialization
    #region singleton
    Storage<Product> firstInstance = Storage<Product>.Instance();
    Storage<Product> secondInstance = Storage<Product>.Instance();
    if (firstInstance == secondInstance)
        Console.WriteLine("Great, We are same instances");
    else
        Console.WriteLine("Singleton failed me");

    #endregion singleton


}
catch (Exception ex) { Console.WriteLine(ex.ToString()); }

static void Message(string name, DateTime d)
{
    Console.WriteLine($"{name} термін зберігання є перевищено {d.Date}!");
}
static void AddToLog(string name, DateTime d)
{
    Log.Add($"{name} термін зберігання є перевищено {d.Date}!");
}
