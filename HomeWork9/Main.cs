internal class Main
{
  public void MainProject()
  {
    Console.Clear();

    Tasks t = new Tasks();
    Methods m = new Methods();

    bool isWork = true;
    string mainMenuText = $"Если хотите вызвать справку, напишите - /help.{Environment.NewLine}"
                        + $"Если хотите завершить работу программы, напишите - exit.{Environment.NewLine}"
                        + $"Если хотите очистить терминал, напишите clear.{Environment.NewLine}{Environment.NewLine}"
                        + $"Какую задачу хотите проверить?{Environment.NewLine}Напишите номер задачи от 1 до 3: ";

    while (isWork)
    {
      Console.Write(mainMenuText);
      string word = Console.ReadLine();
      Console.WriteLine();

      if (m.CheckNumberOfTask(word))
      {
        t.RunProgram(word);
        m.ToEndTask();
      }
      else if (word.ToLower() == "e" || word.ToLower() == "exit" || word.ToLower() == "у")
      {
        isWork = false;
      }
      else if (word.ToLower() == "c" || word.ToLower() == "clear" || word.ToLower() == "с")
      {
        Console.Clear();
      }
      else if (word.ToLower() == "/help" || word.ToLower() == "h" || word.ToLower() == "р")
      {
        m.ToHelp();
      }
      else
      {
        m.CantFindTask();
      }
    }
  }
}
