using System;
using System.Collections.Generic;

namespace zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Start();
        }
    }
}

class Zoo
{
    private Cage _cage1;
    private Cage _cage2;
    private Cage _cage3;
    private Cage _cage4;

    private bool _isWork = true;

    public Zoo()
    {
        _cage1 = new Cage(1, "Медведь", "Рёв");
        _cage2 = new Cage(2, "Сова", "У - У");
        _cage3 = new Cage(3, "Волк", "АУФ");
        _cage4 = new Cage(4, "Осёл", "И-а");
    }

    public void Start()
    {
        const string NumberCage1 = "1";
        const string NumberCage2 = "2";
        const string NumberCage3 = "3";
        const string NumberCage4 = "4";
        const string KeyForExit = "5";

        while (_isWork)
        {
            Console.WriteLine($"Нажмите {NumberCage1}, чтобы подойти к клетке №1\n" +
                $"Нажмите {NumberCage2}, чтобы подойти к клетке №2\n" +
                $"Нажмите {NumberCage3}, чтобы подойти к клетке №2\n" +
                $"Нажмите {NumberCage4}, чтобы подойти к клетке №2\n" +
                $"Нажмите {KeyForExit}, чтобы выйти.");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case NumberCage1:
                    _cage1.ShowInfo();
                    break;
                case NumberCage2:
                    _cage2.ShowInfo();
                    break;
                case NumberCage3:
                    _cage3.ShowInfo();
                    break;
                case NumberCage4:
                    _cage4.ShowInfo();
                    break;
                case KeyForExit:
                    _isWork = false;
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
            }

            Console.ReadLine();
            Console.Clear();
        }
    }
}

class Cage
{
    private static Random _random = new Random();
    private List<Animal> _animals = new List<Animal>();

    private int _number;
    private int _animalsCount;
    private int _maleCount;
    private int _femaleCount;

    public Cage(int numberCage, string species, string biologicalSound)
    {
        string maleGender = "Самец";
        int minimumAnimals = 1;
        int maximumAnimals = 6;

        _number = numberCage;
        _maleCount = 0;
        _femaleCount = 0;
        _animalsCount = _random.Next(minimumAnimals, maximumAnimals);

        for (int i = 0; i < _animalsCount; i++)
        {
            _animals.Add(new Animal(species, biologicalSound));

            if (_animals[i].Gender == maleGender)
            {
                _maleCount++;
            }
            else
            {
                _femaleCount++;
            }
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"____________Вольер №{_number}____________:\n" +
            $"Вид животного: {_animals[0].Species}\n" +
            $"Биологический издаваемый звук: {_animals[0].BiologicalSound}\n" +
            $"Количество животных: {_animalsCount}\n" +
            $"Количество самцов: {_maleCount}\n" +
            $"Количество самок: {_femaleCount}");
    }
}

class Animal
{
    private static Random _random = new Random();

    public Animal(string species, string biologicalSound)
    {
        int maximumRandomValue = 2;
        int value = _random.Next(maximumRandomValue);

        if (value == 0)
        {
            Gender = "Самец";
        }
        else
        {
            Gender = "Самка";
        }

        Species = species;
        BiologicalSound = biologicalSound;
    }

    public string Species { get; private set; }
    public string Gender { get; private set; }
    public string BiologicalSound { get; private set; }
}
