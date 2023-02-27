internal class Tasks
{
  Methods m = new Methods();

  public void RunProgram(string word)
  {
    switch (word)
    {
      case "1":
        {
          Task64_FromNToOne();
          break;
        }
      case "2":
        {
          Task66_SumOfNaturalFromMToN();
          break;
        }
      case "3":
        {
          Task68_AckermanFunction();
          break;
        }
    }
  }

  public void Task64_FromNToOne()
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}"
                + $"Вывести все натуральные числа от N до 1.{Environment.NewLine}";
    Console.WriteLine(text);

    int n = m.ReadInt("число N");

    if (m.CheckPositive(n))
    {
      m.PrintFromNToOneRecursion(n);
      Console.WriteLine();
    }
    else
    {
      Console.WriteLine("Число меньше 1");
    }
  }

  public void Task66_SumOfNaturalFromMToN()
  {
    string text = $"Вы выбрали задачу номер 2{Environment.NewLine}"
                + $"Вывести сумму всех натуральных элементов в промежутке от M до N.{Environment.NewLine}";
    Console.WriteLine(text);

    int n1 = m.ReadInt("число М");
    int n2 = m.ReadInt("число N");
    int sum = 0;

    if (n1 == n2)
    {
      Console.WriteLine("Числа равны");
    }
    else if (m.CheckNumbers(n1, n2))
    {
      if (n1 > n2)
      {
        sum = m.CalculateSumOfNaturalFromMToNRecursion(n1, n2);
        Console.WriteLine($"Сумма всех элементов от {n1} до {n2} равна {sum}");
      }
      else if (n2 > n1)
      {
        sum = m.CalculateSumOfNaturalFromMToNRecursion(n2, n1);
        Console.WriteLine($"Сумма всех элементов от {n2} до {n1} равна {sum}");
      }
    }
  }

  public void Task68_AckermanFunction()
  {
    string text = $"Вы выбрали задачу номер 3{Environment.NewLine}"
                + $"Вычисление функции Аккермана.{Environment.NewLine}";
    Console.WriteLine(text);

    int n1 = m.ReadInt("число М");
    int n2 = m.ReadInt("число N");
    int result = m.CalculateAckermanRecursion(n1, n2);

    Console.WriteLine($"A({n1}, {n2}) = {result}");
  }
}

