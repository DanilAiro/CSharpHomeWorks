public class Methods
{
  #region MethodsForTasks

  public int ReadInt(string arg)
  {
    Console.Write($"Введите {arg}: ");
    int num;

    while (!int.TryParse(Console.ReadLine(), out num))
    {
      Console.Write("Значение не подходит, повторите: ");
    }

    return num;
  }

  public void PrintFromNToOneRecursion(int n)
  {
    if (n > 0)
    {
      Console.Write($"{n} ");
      PrintFromNToOneRecursion(--n);
    }
  }

  public bool CheckPositive(int n)
  {
    if (n > 0) return true;
    else return false;
  }

  public int CalculateSumOfNaturalFromMToNRecursion(int m, int n)
  {
    if (m > n - 1)
    {
      return m + CalculateSumOfNaturalFromMToNRecursion(m - 1, n);
    }

    return 0;
  }

  public bool CheckNumbers(int m, int n)
  {
    if (m < 1 || n < 1)
    {
      return false;
    }

    return true;
  }

  public int CalculateAckermanRecursion(int m, int n)
  {
    if (m == 0)
    {
      return n + 1;
    }
    else if (m > 0 && n == 0)
    {
      return CalculateAckermanRecursion(m - 1, 1);
    }
    else if (m > 0 && n > 0)
    {
      return CalculateAckermanRecursion(m - 1, CalculateAckermanRecursion(m, n - 1));
    }

    return 0;
  }

  #endregion

  #region MethodsForWork

  public bool CheckNumberOfTask(string number)
  {
    return (number == "1" || number == "2" || number == "3" || number == "4" || number == "5");
  }

  public void ToEndTask()
  {
    Console.WriteLine($"Для возврата в главное меню, нажмите любую кнопку{Environment.NewLine}");
    Console.ReadKey();
  }

  public void ToHelp()
  {
    Console.Clear();
    string text = $"Справка:{Environment.NewLine}1. Вывести все натуральные числа от N до 1.{Environment.NewLine}"
                + $"2. Вывести сумму всех натуральных элементов в промежутке от M до N.{Environment.NewLine}"
                + $"3. Вычисление функции Аккермана.{Environment.NewLine}"
                + $"/help или /h. Справка{Environment.NewLine}Exit или E. Завершение работы программы";

    Console.WriteLine(text);
    ToEndTask();
    Console.Clear();
  }

  public void CantFindTask()
  {
    Console.WriteLine($"Команда не была распознана, повторите ввод{Environment.NewLine}");
  }

  #endregion
}


