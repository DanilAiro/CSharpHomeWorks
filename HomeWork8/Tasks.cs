internal class Tasks
{
  Methods m = new Methods();

  public void Task54_SortRowsInArray()
  {
    string text = $"Вы выбрали задачу номер 1{Environment.NewLine}Упорядочить по убыванию элементы каждой строки двумерного массива.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = m.GetTwoDimensionArray(m.ReadInt("первую длину"), m.ReadInt("вторую длину"));
    int minValue = m.ReadInt("минимальное значение наполнения");
    int maxValue = m.ReadInt("максимальное значение наполнения");

    m.FillRandomlyTwoDimensionArray(array, minValue, maxValue);
    m.PrintTwoDimensionArray(array);
    m.SortRowsInArray(array);
    m.PrintTwoDimensionArray(array);
  }

  public void Task56_FindRowWithMinimalSum()
  {
    string text = $"Вы выбрали задачу номер 2{Environment.NewLine}Найти строку с наименьшей суммой элементов.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = m.GetTwoDimensionArray(m.ReadInt("первую длину"), m.ReadInt("вторую длину"));
    int minValue = m.ReadInt("минимальное значение наполнения");
    int maxValue = m.ReadInt("максимальное значение наполнения");
    Console.WriteLine();

    m.FillRandomlyTwoDimensionArray(array, minValue, maxValue);
    m.PrintTwoDimensionArray(array);
    int indexOfRow = m.FindRowWithMinimalSum(array);
    string row = m.CopyRowFromArray(array, indexOfRow);

    Console.WriteLine($"Индекс ряда [{row}] с минимальной суммой: {indexOfRow}{Environment.NewLine}");
  }

  public void Task58_MultiplyMatrix()
  {
    string text = $"Вы выбрали задачу номер 3{Environment.NewLine}"
                + $"Найти произведение двух матриц.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = new int[m.ReadInt("первую длину первой матрицы"), m.ReadInt("вторую длину первой матрицы")];
    int[,] arr = new int[m.ReadInt("первую длину второй матрицы"), m.ReadInt("вторую длину второй матрицы")];
    bool checkArrays = m.CheckMyMatrixBeforeMultiply(array, arr);

    if (checkArrays)
    {
      Console.WriteLine($"{Environment.NewLine}Такие матрицы можно перемножать.{Environment.NewLine}");

      var firstMethod = m.ChooseFillingMethod("первый");
      array = m.FillArrayLikeDecided(firstMethod.first, firstMethod.second, array);

      var secondMethod = m.ChooseFillingMethod("второй");
      arr = m.FillArrayLikeDecided(secondMethod.first, secondMethod.second, arr);

      int[,] result = new int[array.GetLength(0), arr.GetLength(1)];

      m.MultiplyTwoMatrix(array, arr, result);
      m.PrintTwoDimensionArray(result);
    }
    else
    {
      Console.WriteLine($"{Environment.NewLine}Такие матрицы нельзя перемножить, так как количество столбцов первой матрицы не равно количеству строк второй матрицы.");
    }
  }

  public void Task60_FillThreeDimensionArrayWIthTwoUnicDigits()
  {
    string text = $"Вы выбрали задачу номер 4{Environment.NewLine}"
                + $"Сформировать трёхмерный массив из неповторяющихся двузначных чисел.{Environment.NewLine}";
    Console.WriteLine(text);

    int[] randomNumbers = new int[90];
    m.FillArrayWithTwoUnicDigits(randomNumbers);

    int[,,] result;
    int firstLength = 0;
    int secondLength = 0;
    int thirdLength = 0;
    bool isLegit = false;

    while (!isLegit)
    {
      firstLength = m.ReadInt("первую длину");
      secondLength = m.ReadInt("вторую длину");
      thirdLength = m.ReadInt("третью длину");
      Console.WriteLine();

      if (firstLength * secondLength * thirdLength <= 90)
      {
        isLegit = true;
      }
      else
      {
        Console.WriteLine($"Размер вашего массива больше 90 элементов, не хватит уникальных чисел.{Environment.NewLine}"
                        + $"Попробуйте ещё раз.{Environment.NewLine}");
      }
    }

    result = new int[firstLength, secondLength, thirdLength];
    m.FillThreeDimensionArray(result, randomNumbers);
    m.PrintThreeDimensionArray(result);
  }

  public void Task62_FillArraySpirally()
  {
    string text = $"Вы выбрали задачу номер 5{Environment.NewLine}"
                + $"Заполнить массив спирально.{Environment.NewLine}";
    Console.WriteLine(text);

    int[,] array = new int[m.ReadInt("первую длину"), m.ReadInt("вторую длину")];
    m.PrintTwoDimensionArray(array);

    bool isPlus = true;
    bool isHorizontal = true;
    int quantity = array.GetLength(0) * array.GetLength(1);
    int n = 1;
    int i = 0;
    int j = 0;
    int xOffset = 0;
    int yOffset = 0;


    while (n <= quantity)
    {
      if (isHorizontal)
      {
        if (isPlus)
        {
          if (j < array.GetLength(1) - xOffset)
          {
            array[i, j++] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            i++;
            j--;
            isHorizontal = false;
          }
        }
        else
        {
          if (j > xOffset)
          {
            array[i, --j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            isHorizontal = false;
            xOffset++;
          }
        }
      }
      else //vertical
      {
        if (isPlus)
        {
          if (i < array.GetLength(0) - yOffset)
          {
            array[i++, j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            i--;
            isHorizontal = true;
            isPlus = false;
            yOffset++;
          }
        }
        else
        {
          if (i > yOffset)
          {
            array[--i, j] = n++;
            m.PrintTwoDimensionArray(array);
            Console.ReadKey();
          }
          else
          {
            j++;
            isHorizontal = true;
            isPlus = true;
          }
        }
      }
    }
  }
}

