using System;
using System.Collections.Generic;

// Власний виняток
public class InvalidCargoCapacityException : Exception
{
    public InvalidCargoCapacityException(string message) : base(message) { }
}

// Інтерфейс Trans
public interface Trans
{
    void ShowInfo();
    double GetCargoCapacity();
}

// Абстрактний базовий клас
abstract class TransportBase : Trans
{
    public string Brand { get; set; }
    public string Number { get; set; }
    public double Speed { get; set; }

    public TransportBase(string brand, string number, double speed)
    {
        Brand = brand;
        Number = number;
        Speed = speed;
    }

    public abstract void ShowInfo();
    public abstract double GetCargoCapacity();
}

// Легкова машина
class Car : TransportBase
{
    public double CargoCapacity { get; set; }

    public Car(string brand, string number, double speed, double cargoCapacity)
        : base(brand, number, speed)
    {
        if (cargoCapacity < 0)
            throw new InvalidCargoCapacityException("Вантажопідйомність не може бути від'ємною.");

        CargoCapacity = cargoCapacity;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Легкова машина: {Brand}, Номер: {Number}, Швидкість: {Speed}, Вантажопідйомність: {CargoCapacity}");
    }

    public override double GetCargoCapacity() => CargoCapacity;
}

// Програма з обробкою помилок
class Program
{
    static void Main()
    {
        try
        {
            // Симуляція помилки власного типу
            Trans car = new Car("Toyota", "AA1234BB", 180, -100); // Помилка!
        }
        catch (InvalidCargoCapacityException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        try
        {
            // Симуляція стандартного винятку InvalidCastException
            object obj = "Я не транспорт";
            Trans t = (Trans)obj; // Спроба неправильного приведення типу
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("Standard .NET Exception: " + ex.Message);
        }

        Console.WriteLine("\nПрограма завершила роботу.");
    }
}
