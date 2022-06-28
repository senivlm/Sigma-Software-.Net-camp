using task12;
using task12.add;

try
{

    Storage<Product> productStorage = new Storage<Product>();
    productStorage.DateExpied += Message;
    productStorage.DateExpied += AddToLog;
    Dairy_products milk = new Dairy_products(new DateTime(15,10,15), "Milk", 100, 0.9);
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
    
    
    Check.Output(productStorage);
    Console.WriteLine(Log.ShowLogs());
    List<string> s = new List<string>();
    Console.WriteLine("SEARCHING Sandwich" );
    foreach (var item in productStorage.Search("Sandwich"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING 40");
    foreach (var item in productStorage.Search("40"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING 0.9");
    foreach (var item in productStorage.Search("0.9"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING 27.06.2022");
    foreach (var item in productStorage.Search("27.06.2022"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING First");
    foreach (var item in productStorage.Search("First"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING Highest");
    foreach (var item in productStorage.Search("Highest"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING Lamb");
    foreach (var item in productStorage.Search("Lamb"))
        Console.WriteLine(item.ToString());
    Console.WriteLine("SEARCHING Hello");
    foreach (var item in productStorage.Search("Hello"))
        Console.WriteLine(item.ToString());

}
catch (Exception ex) { Console.WriteLine(ex.ToString()); }

 static void Message(string name,DateTime d)
{
    Console.WriteLine($"{name} термін зберігання є перевищено {d.Date}!");
}
 static void AddToLog(string name, DateTime d)
{
    Log.Add($"{name} термін зберігання є перевищено {d.Date}!");
}
