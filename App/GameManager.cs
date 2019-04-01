using System;
using System.Collections.Generic;
using golfCard.Models;

namespace golfCard
{
  class GameManager
  {
    List<Course> Courses { get; set; }
    Game ActiveGame { get; set; }
    public void NewGame()
    {
      Console.WriteLine("Please Select a course to play:");
      for (int i = 0; i < Courses.Count; i++)
      {
        Console.WriteLine($"{i + 1}. {Courses[i].Name");
      }
      Course course = CourseSelection();
      List<Player> players = PlayerSelection();
      ActiveGame = new Game(course, players);
      ActiveGame.Play();
      Console.WriteLine("(Q)uit, or hit any other key to create a new game");
      string again = Console.ReadLine().ToUpper();
      if (again != "Q")
      {
        Console.Clear();
        NewGame();
      }
    }
    public Course CourseSelection()
    {
      bool valid = false;
      int index = -1;
      while (!valid)
      {
        Console.Write("Course > ");
        string stringChoice = Console.ReadLine();
        if (!Int32.TryParse(stringChoice, out index) || index < 1 || index > Courses.Count)
        {
          Console.WriteLine("Invalid Selection, please provide a valid course number");
          continue;
        }
        valid = true;
      }
      return Courses[index - 1];
    }
    public List<Player> PlayerSelection()
    {
      bool valid = false;
      int players = -1;
      List<Player> playerNames = new List<Player>();
      while (!valid)
      {
        Console.Write("Number of Players > ");
        string stringChoice = Console.ReadLine();
        if (!Int32.TryParse(stringChoice, out players) || players < 1)
        {
          Console.WriteLine("Invalid Selection, please provide a valid number");
          continue;
        }
        valid = true;
      }
      for (int i = 0; i < players; i++)
      {
        Console.Write($"Player {i + 1} Name > ");
        playerNames.Add(new Player(Console.ReadLine()));
      }
      return playerNames;
    }
    public GameManager()
    {
      Courses = new List<Course>()
      {
        new Course("Family Fun Center - Fairytale Mini Put", new List<int>() {2,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2}),
        new Course("LaMesa Nine Iron - pitch and put", new List<int>() {3,3,4,3,2,3,4,3,3,4,2,3,3,3,4,3,3,3}),
        new Course("Torrey Pines", new List<int>() {4, 3, 5, 4, 4, 5, 3, 4, 5, 4, 3, 4, 4, 5, 3, 4, 5, 4})
      };
    }
  }
}