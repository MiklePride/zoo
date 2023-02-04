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
    private List<Cage> _cages = new List<Cage>();

    private bool _isWork = true;
    private int _countCages = 0;

    public Zoo()
    {
        _cages.Add(new Cage("Медведь", "Рёв"));
        _cages.Add(new Cage("Сова", "У - У"));
        _cages.Add(new Cage("Волк", "АУФ"));
        _cages.Add(new Cage("Осёл", "И-а"));

        foreach (var cage in _cages)
        {
            _countCages++;
        }
    }

    public void Start()
    {
        while (_isWork)
        {
            Console.WriteLine($"Перед вами {_countCages} вольеров.\n" +
                $"Введите номер вольера, чтобы подойти:");

            int userInput = UserUtils.GetNumber();

            GoToCage(userInput);

            Console.WriteLine($"Нажмите '{(char)ConsoleKey.Y}' для выхода или любую другую клавишу для продолжения");

            char userInputChar = (char)Console.ReadKey().Key;

            if (userInputChar == (char)ConsoleKey.Y)
            {
                _isWork = false;
            }

            Console.Clear();
        }
    }

    private void GoToCage(int numberCage)
    {
        int indexCage = numberCage - 1;

        if (numberCage > 0 && numberCage <= _cages.Count)
        {
            _cages[indexCage].ShowInfo(numberCage);
        }
        else
        {
            Console.WriteLine("Вольера с таким номером нет.");
        }
    }
}

class Cage
{
    private static Random _random = new Random();
    private List<Animal> _animals = new List<Animal>();

    private int _animalsCount;
    private int _maleCount;
    private int _femaleCount;

    public Cage(string species, string biologicalSound)
    {
        string maleGender = "Самец";
        int minimumAnimals = 1;
        int maximumAnimals = 6;

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

    public void ShowInfo(int number)
    {
        Console.WriteLine($"________________________{number}________________________:\n" +
            $"Вид животного: {_animals[0].Species}\n" +
            $"Биологический издаваемый звук: {_animals[0].BiologicalSound}\n" +
            $"Количество животных: {_animalsCount}\n" +
            $"Количество самцов: {_maleCount}\n" +
            $"Количество самок: {_femaleCount}");

        Console.WriteLine();
    }
}

class Animal
{
    private static Random _random = new Random();

    public Animal(string species, string biologicalSound)
    {
        int maximumRandomValue = 2;
        int value = _random.Next(maximumRandomValue);

        if (value == (int)GenderAnimal.Male)
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

    enum GenderAnimal
    {
        Male,
        Female
    }
}

static class UserUtils
{
    public static int GetNumber()
    {
        bool isNumberWork = true;
        int userNumber = 0;

        while (isNumberWork)
        {
            bool isNumber;
            string userInput = Console.ReadLine();

            if (isNumber = int.TryParse(userInput, out int number))
            {
                userNumber = number;
                isNumberWork = false;
            }
            else
            {
                Console.WriteLine($"Не правильный ввод данных!!!  Повторите попытку");
            }
        }
        return userNumber;
    }
}