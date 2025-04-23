using System;
using System.Collections;
using System.Collections.Generic;

// Клас Деталь
class Detail
{
    public string Name { get; set; }
    public string Material { get; set; }
    public double Weight { get; set; }

    public Detail(string name, string material, double weight)
    {
        Name = name;
        Material = material;
        Weight = weight;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Деталь: {Name}, Матеріал: {Material}, Вага: {Weight} кг");
    }
}

// Клас Механізм
class Mechanism
{
    public string Type { get; set; }
    public List<Detail> Details { get; set; } = new List<Detail>();

    public Mechanism(string type)
    {
        Type = type;
    }

    public void AddDetail(Detail detail)
    {
        Details.Add(detail);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Механізм: {Type}");
        foreach (var detail in Details)
            detail.Show();
    }
}

// Клас Вузол
class Node
{
    public string Name { get; set; }
    public List<Mechanism> Mechanisms { get; set; } = new List<Mechanism>();

    public Node(string name)
    {
        Name = name;
    }

    public void AddMechanism(Mechanism mech)
    {
        Mechanisms.Add(mech);
    }

    public virtual void Show()
    {
        Console.WriteLine($"Вузол: {Name}");
        foreach (var mech in Mechanisms)
            mech.Show();
    }
}

// Клас Виріб з підтримкою foreach
class Product : IEnumerable<Node>
{
    public string Name { get; set; }
    private List<Node> Nodes { get; set; } = new List<Node>();

    public Product(string name)
    {
        Name = name;
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void Show()
    {
        Console.WriteLine($"Виріб: {Name}");
        foreach (var node in Nodes)
            node.Show();
    }

    public IEnumerator<Node> GetEnumerator() => Nodes.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Тестування
class Program
{
    static void Main()
    {
        // Створення об'єктів
        var d1 = new Detail("Шестірня", "Сталь", 0.25);
        var d2 = new Detail("Кришка", "Пластик", 0.15);

        var mech = new Mechanism("Редуктор");
        mech.AddDetail(d1);
        mech.AddDetail(d2);

        var node = new Node("Корпус");
        node.AddMechanism(mech);

        var product = new Product("Електродвигун");
        product.AddNode(node);

        // Виведення через метод
        product.Show();

        Console.WriteLine("\nПеребір вузлів через foreach:");
        foreach (var n in product)
        {
            n.Show();
        }
    }
}
