namespace ooa_2_husrum_ef.Utils.Helpers
{
  using ooa_2_husrum_ef.Database;
  using System.Collections.Generic;
  using System.Linq;
  using ooa_2_husrum_ef.Models;
  using Microsoft.EntityFrameworkCore;

  static class TagHelper
  {
    private static readonly string AllowedTagLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    /// Looks through currently in use tag ids for specified apartment and finds the next first alphabethically available. 
    /// E.g. if tags 0301A, 0301B, and 0301D are in use, 0301C will be returned. 
    /// </summary>
    /// <param name="apartmentId">Apartment id for which to get a tag id.</param>
    /// <returns>Returns an available tag id, or an empty string if none is available.</returns>
    public static string GetNextApartmentTag(string apartmentId)
    {
      // Get all currently assigned tag letters for apartment.
      var tagLettersInUse = new List<string>();
      using (var context = new LogsContext())
      {
        var tags = context.Tags
          .Include(t => t.Tenant)
          .Where(t => t.Tenant.ApartmentId == apartmentId)
          .ToList();

        foreach (Tag tag in tags)
        {
          tagLettersInUse.Add(tag.Id.Substring(apartmentId.Length));
        }
      }

      // Make sure they are sorted or trouble when assuming letter is available.
      tagLettersInUse.Sort();

      // Find first letter in the alphabet that is not currently in use by a tenant. 
      foreach (char letter in AllowedTagLetters.ToCharArray())
      {
        // Assume its available until proven it's not. 
        var isLetterAvailable = true;

        foreach (string tagLetter in tagLettersInUse)
        {
          // Is letter in use by tag?
          if (tagLetter.IndexOf(letter) >= 0) // index of 'A' in "A"? => 0 => true
          {
            isLetterAvailable = false;
            // It's in use, no reason looking at the other tags for this letter. 
            break;
          }
        }
        if (isLetterAvailable)
        {
          return $"{apartmentId}{letter}";
        }
      }

      // Return empty string if all allowed letters are in use. 
      return "";
    }
  }
}
