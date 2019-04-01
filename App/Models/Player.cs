using System;
using System.Collections.Generic;

namespace golfCard.Models
{
  class Player
  {
    public string Name { get; private set; }
    List<int> Scores { get; set; }
    public int TotalScore { get; private set; }
    public void AddScore(int score)
    {
      TotalScore += score;
      Scores.Add(score);
    }
    public string GetScoreCard()
    {
      string scorecard = "";
      scorecard += PlayerName();
      foreach (var score in Scores)
      {
        scorecard += score + " ";
      }
      return scorecard;
    }
    string PlayerName()
    {
      string name = Name;
      return name;
    }
    public Player(string name)
    {
      Name = name;
      Scores = new List<int>();
    }
  }
}