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

  public void PrintTwoDimensionArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        Console.Write($"{array[i, j]} ");
      }

      Console.WriteLine();
    }

    Console.WriteLine();
  }

  public void PrintThreeDimensionArray(int[,,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        for (int k = 0; k < array.GetLength(2); k++)
        {
          Console.WriteLine($"{array[i, j, k]}({i}, {j}, {k})");
        }
      }
    }

    Console.WriteLine();
  }

  public int[,] GetTwoDimensionArray(int firstLength, int secondLength)
  {
    int[,] array = new int[firstLength, secondLength];

    return array;
  }

  public void FillRandomlyTwoDimensionArray(int[,] array, int minValue, int maxValue)
  {
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        array[i, j] = random.Next(minValue, maxValue + 1);
      }
    }
  }
  public void FillArrayWithTwoUnicDigits(int[] array)
  {
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
      bool isUnic = false;

      while (!isUnic)
      {
        array[i] = random.Next(10, 100);

        if (CheckArrayUnic(array, i))
        {
          isUnic = true;
        }
      }
    }
  }

  public bool CheckArrayUnic(int[] array, int i)
  {
    for (int j = 0; j < i; j++)
    {
      if (i == 0)
      {
        return true;
      }
      else if (array[i] == array[j])
      {
        return false;
      }
    }

    return true;
  }

  public void FillThreeDimensionArray(int[,,] array, int[] numbers)
  {
    int l = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        for (int k = 0; k < array.GetLength(2); k++)
        {
          array[i, j, k] = numbers[l++];
        }
      }
    }
  }

  public void FillManuallyTwoDimensionArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        array[i, j] = ReadInt($"число на позицию [{i}, {j}]");
      }
    }
  }

  public int[,] FillArrayLikeDecided(bool whatMethod, int whatMethodNumber, int[,] array)
  {
    if (whatMethod)
    {
      if (whatMethodNumber == 1)
      {
        FillManuallyTwoDimensionArray(array);
        Console.WriteLine();
        PrintTwoDimensionArray(array);
        return array;
      }
      else if (whatMethodNumber == 2)
      {
        FillRandomlyTwoDimensionArray(array, ReadInt("минимальное значение наполнения"), ReadInt("максимальное значение наполнения"));
        Console.WriteLine();
        PrintTwoDimensionArray(array);
        return array;
      }
    }

    Console.WriteLine($"Команду неудалось распознать, заполним случайным образом.{Environment.NewLine}");

    FillRandomlyTwoDimensionArray(array, 1, 9);
    PrintTwoDimensionArray(array);
    return array;
  }

  public void SortRowsInArray(int[,] array)
  {
    for (int i = 0; i < array.GetLength(0); i++)
    {
      for (int j = 0; j < array.GetLength(1); j++)
      {
        SortRowInArray(array, i, j);
      }
    }
  }

  public void SortRowInArray(int[,] array, int i, int j)
  {
    for (int k = j + 1; k < array.GetLength(1); k++)
    {
      if (array[i, j] < array[i, k])
      {
        int temporary = array[i, k];
        array[i, k] = array[i, j];
        array[i, j] = temporary;
      }
    }
  }

  public int FindRowWithMinimalSum(int[,] array)
  {
    int minSum = int.MaxValue;
    int index = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
      int rowSum = 0;

      for (int j = 0; j < array.GetLength(1); j++)
      {
        rowSum += array[i, j];
      }

      if (minSum > rowSum)
      {
        minSum = rowSum;
        index = i;
      }
    }

    return index;
  }

  public string CopyRowFromArray(int[,] array, int indexOfRow)
  {
    string result = string.Empty;

    for (int j = 0; j < array.GetLength(1); j++)
    {
      if (j == array.GetLength(1) - 1)
      {
        result += $"{array[indexOfRow, j]}";
      }
      else
      {
        result += $"{array[indexOfRow, j]}, ";
      }
    }

    return result;
  }

  public (bool first, int second) ChooseFillingMethod(string arg)
  {
    Console.WriteLine($"Каким способом хотите заполнить {arg} массив? Введите \"1\" для ручного заполнения или \"2\" для случайного наполнения.");
    int number = ReadInt("цифру");

    if (number == 1)
    {
      return (true, 1);
    }
    else if (number == 2)
    {
      return (true, 2);
    }
    else
    {
      return (false, 0);
    }
  }

  public bool CheckMyMatrixBeforeMultiply(int[,] firstArray, int[,] secondArray)
  {
    if (firstArray.GetLength(1) == secondArray.GetLength(0))
    {
      return true;
    }
    else
    {
      return false;
    }
  }

  public void MultiplyTwoMatrix(int[,] firstArray, int[,] secondArray, int[,] result)
  {
    for (int i = 0; i < result.GetLength(0); i++)
    {
      for (int j = 0; j < result.GetLength(1); j++)
      {
        result[i, j] = CalculateElementRecursion(firstArray, secondArray, i, j, 0);
      }
    }
  }

  public int CalculateElementRecursion(int[,] firstArray, int[,] secondArray, int i, int j, int index)
  {
    if (firstArray.GetLength(1) > index && secondArray.GetLength(0) > index)
    {
      return firstArray[i, index] * secondArray[index, j] + CalculateElementRecursion(firstArray, secondArray, i, j, index + 1);
    }

    return 0;
  }

  public void FillArraySpirally(int[,] array)
  {
    int n = 1;
    int i = 0;
    int j = 0;
    array[i, j] = n;
    int check = CheckDirection(array, n);

    while (n <= array.GetLength(0) * array.GetLength(1))
    {

      switch (check)
      {
        case 1:
          if (array[i, j + 1] == 0) array[i, j++] = n++;
          check = CheckDirection(array, n);
          break;

        case 2:
          if (array[i + 1, j] == 0) array[i++, j] = n++;
          check = CheckDirection(array, n);
          break;

        case -1:
          if (array[i, j - 1] == 0) array[i, j--] = n++;
          check = CheckDirection(array, n);
          break;

        case -2:
          if (array[i - 1, j] == 0) array[i--, j] = n++;
          check = CheckDirection(array, n);
          break;
      }

    }
  }

  public int CheckDirection(int[,] array, int n)
  {
    while (n <= array.GetLength(0) * array.GetLength(1))
    {
      if (n < array.GetLength(1))
      {
        return 1;
      }
      else if (n < array.GetLength(0) + array.GetLength(1) - 2)
      {
        return 2;
      }
      else if (n < array.GetLength(1) * 2 + array.GetLength(0) - 3)
      {
        return -1;
      }
      else if (n < array.GetLength(0) * 2 + array.GetLength(1) * 2 - 4)
      {
        return -2;
      }
    }

      return 1;
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
    string text = $"Справка:{Environment.NewLine}1. Посчитать, сколько введено чисел больше 0.{Environment.NewLine}"
                + $"2. Нахождение точки пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2.{Environment.NewLine}"
                + $"/help или /h. Справка{Environment.NewLine}Exit или E. Завершение работы программы";

    Console.WriteLine(text);
    ToEndTask();
    Console.Clear();
  }

  #endregion
}


