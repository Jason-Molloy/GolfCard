using System;
using System.Collections.Generic;

namespace golfCard.Models
{
  class Course
  {
    public string Name { get; set; }
    public List<int> HolePars { get; set; }
    public int ParTotal { get; set; }

    public string CourseCard()
    {
      string courseCard = Name + "Par:   ";
      foreach (int par in HolePars)
      {
        courseCard += par.ToString() + " ";
      }
      return courseCard;
    }

    public Course(string name, List<int> holePars)
    {
      Name = name;
      HolePars = holePars;
      int total = 0;
      foreach (var par in holePars)
      {
        total += par;
      }
      ParTotal = total;
    }
  }
}