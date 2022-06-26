using task11;
using task11.additional;

try
{
    Storage<Meat> meatStorage = new Storage<Meat>();
    meatStorage.InputFromFiles();
    Check.Output(meatStorage);
    Console.WriteLine(meatStorage.ShowLogs());

    Storage<Dairy_products> dairyStorage = new Storage<Dairy_products>();
    dairyStorage.InputFromFiles();
    Check.Output(dairyStorage);
    Console.WriteLine(dairyStorage.ShowLogs());

    Storage<Product> productStorage = new Storage<Product>();
    productStorage.InputFromFiles();
    Check.Output(productStorage);
    Console.WriteLine(productStorage.ShowLogs());
}
catch (Exception ex) { Console.WriteLine(ex.ToString()); }
