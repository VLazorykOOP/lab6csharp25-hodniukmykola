using System;
using System.Collections.Generic;

// Інтерфейс Trans, який також реалізує IComparable
public interface Trans : IComparable<Trans>
{
    void ShowInfo();
    double GetCargoCapacity();
}

// Базовий клас Транспорт
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

    public int CompareTo(Trans other)
    {
        return GetCargoCapacity().CompareTo(other.GetCargoCapacity());
    }
}

// Легкова машина
class Car : TransportBase
{
    public double CargoCapacity { get; set; }

    public Car(string brand, string number, double speed, double cargoCapacity)
        : base(brand, number, speed)
    {
        CargoCapacity = cargoCapacity;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Легкова машина: {Brand}, Номер: {Number}, Швидкість: {Speed} км/год, Вантажопідйомність: {CargoCapacity} кг");
    }

    public override double GetCargoCapacity() => CargoCapacity;
}

// Мотоцикл
class Motorcycle : TransportBase
{
    public bool HasSidecar { get; set; }
    public double BaseCapacity { get; set; }

    public Motorcycle(string brand, string number, double speed, bool hasSidecar, double baseCapacity)
        : base(brand, number, speed)
    {
        HasSidecar = hasSidecar;
        BaseCapacity = baseCapacity;
    }

    public override void ShowInfo()
    {
        double capacity = GetCargoCapacity();
        Console.WriteLine($"Мотоцикл: {Brand}, Номер: {Number}, Швидкість: {Speed} км/год, Коляска: {(HasSidecar ? "так" : "ні")}, Вантажопідйомність: {capacity} кг");
    }

    public override double GetCargoCapacity() => HasSidecar ? BaseCapacity : 0;
}

// Вантажівка
class Truck : TransportBase
{
    public double BaseCapacity { get; set; }
    public bool HasTrailer { get; set; }

    public Truck(string brand, string number, double speed, double baseCapacity, bool hasTrailer)
        : base(brand, number, speed)
    {
        BaseCapacity = baseCapacity;
        HasTrailer = hasTrailer;
    }

    public override void ShowInfo()
    {
        double capacity = GetCargoCapacity();
        Console.WriteLine($"Вантажівка: {Brand}, Номер: {Number}, Швидкість: {Speed} км/год, Причеп: {(HasTrailer ? "так" : "ні")}, Вантажопідйомність: {capacity} кг");
    }

    public override double GetCargoCapacity() => HasTrailer ? BaseCapacity * 2 : BaseCapacity;
}

// Основна програма
class Program
{
    static void Main()
    {
        List<Trans> transportBase = new List<Trans>
        {
            new Car("Toyota", "AA1234BB", 180, 500),
            new Motorcycle("Honda", "BB5678CC", 160, true, 50),
            new Motorcycle("Yamaha", "CC9101DD", 170, false, 50),
            new Truck("MAN", "DD1122EE", 120, 3000, true),
            new Truck("Volvo", "EE3344FF", 110, 3500, false)
        };

        Console.WriteLine("Усі транспортні засоби:");
        foreach (var t in transportBase)
            t.ShowInfo();

        Console.WriteLine("\nВведіть мінімальну вантажопідйомність:");
        if (double.TryParse(Console.ReadLine(), out double minCapacity))
        {
            Console.WriteLine($"\nТранспорт з вантажопідйомністю не менш ніж {minCapacity} кг:");
            foreach (var t in transportBase)
            {
                if (t.GetCargoCapacity() >= minCapacity)
                    t.ShowInfo();
            }
        }
        else
        {
            Console.WriteLine("Некоректне значення.");
        }
    }
}
