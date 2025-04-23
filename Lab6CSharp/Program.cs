using System;
using System.Collections.Generic;

// Інтерфейси
interface INamed
{
    string Name { get; set; }
}

interface IShowable
{
    void Show();
}

// Базовий клас - Деталь
class Detail : INamed, IShowable
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

// Механізм успадковується від Деталі
class Mechanism : Detail
{
    public List<Detail> Details { get; set; } = new List<Detail>();

    public Mechanism(string name, string material, double weight)
        : base(name, material, weight)
    {
    }

    public void AddDetail(Detail detail)
    {
        Details.Add(detail);
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Механізм: {Name}");
        foreach (var d in Details)
            d.Show();
    }
}

// Вузол успадковується від Механізму
class Node : Mechanism
{
    public List<Mechanism> Mechanisms { get; set; } = new List<Mechanism>();

    public Node(string name, string material, double weight)
        : base(name, material, weight)
    {
    }

    public void AddMechanism(Mechanism mech)
    {
        Mechanisms.Add(mech);
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Вузол: {Name}");
        foreach (var m in Mechanisms)
            m.Show();
    }
}

// Виріб успадковується від Вузла
class Product : Node
{
    public List<Node> Nodes { get; set; } = new List<Node>();

    public Product(string name, string material, double weight)
        : base(name, material, weight)
    {
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public override void Show()
    {
        Console.WriteLine($"Виріб: {Name}");
        foreach (var n in Nodes)
            n.Show();
    }
}

// Демонстрація
class Program
{
    static void Main()
    {
        Detail d1 = new Detail("Гвинт", "Сталь", 0.1);
        Detail d2 = new Detail("Кришка", "Пластик", 0.5);

        Mechanism mech = new Mechanism("Привід", "Метал", 1.2);
        mech.AddDetail(d1);
        mech.AddDetail(d2);

        Node node = new Node("Корпус", "Алюміній", 2.5);
        node.AddMechanism(mech);

        Product product = new Product("Свердло", "Комбіноване", 3.5);
        product.AddNode(node);

        product.Show();
    }
}
