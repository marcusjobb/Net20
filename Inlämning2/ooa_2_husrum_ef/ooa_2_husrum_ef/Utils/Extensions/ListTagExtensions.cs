namespace ooa_2_husrum_ef.Utils.Extensions
{
  using ooa_2_husrum_ef.Models;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public static class ListTagExtensions
  {
    /// <summary>
    /// Writes the names and tag ids for a collection of tags to the console. 
    /// </summary>
    /// <param name="tags">Set of tags to write to console.</param>
    /// <param name="title">Describes this set of tags.</param>
    public static void Write(this List<Tag> tags, string title)
    {
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine(title);
      Console.ResetColor();

      if (tags != null && tags.Count > 0)
      {
        foreach (Tag tag in tags)
        {
          Console.WriteLine($"{tag.Id} {tag.Tenant.Name}");
        }
      }
      else
      {
        Console.WriteLine("No entries found.");
      }

      Console.WriteLine();
    }
  }
}
