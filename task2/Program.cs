using System;
using task2.Task1;
using task2.Task1.task2;

namespace task2
{
    class Program
    {
        static void Main()
        {
            Dairy_products milk = new Dairy_products(10, "Milk", 100, 0.9);
            milk.ChangePrice(100);
            Check.Output(milk);
            milk.ExpireDate = 5;
            milk.ChangePrice(0);
            Check.Output(milk);
            milk.ExpireDate = 1;
            milk.ChangePrice(0);
            Check.Output(milk);

            Meat lamb = new Meat(Category.Highest, MeatType.Lamb, "Lamb", 100, 50);
            lamb.ChangePrice(100);
            Check.Output(lamb);

            Product[] arr = new Product[5];
            arr[0] = new Product("Ice-cream", 22, 0.08);
            arr[1] = milk;
            arr[2] = lamb;
            arr[3] = new Product("Sandwich", 40, 0.05);
            arr[4] = lamb;

            Storage storage = new Storage(arr);
            storage.Output();
            storage.FindMeat();
            storage.UserInput();
            storage.Output();
            storage.ChangePrice(50);
            storage.Output();
            storage[0] = lamb;
            storage.Output();

            task2Matrix matrix1 = new task2Matrix(3, 6);
            Console.WriteLine("__Fill Vertical Snake__");
            matrix1.FillVerticalSnake();
            matrix1.Output();
            task2Matrix matrix2 = new task2Matrix(6, 6);
            Console.WriteLine("__Fill Diagonal Snake__");
            matrix2.FillDiagonalSnake();
            matrix2.Output();
            Console.WriteLine("__Fill Spiral Snake__");
            task2Matrix matrix3 = new task2Matrix(6, 5);
            matrix3.FillSpiralSnake();
            matrix3.Output();
        }
    }
}
