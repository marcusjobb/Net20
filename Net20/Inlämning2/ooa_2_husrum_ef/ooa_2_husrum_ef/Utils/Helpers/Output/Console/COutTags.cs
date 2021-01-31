namespace ooa_2_husrum_ef.Utils.Helpers.Output.Console
{
  using ooa_2_husrum_ef.Interfaces;
  using ooa_2_husrum_ef.Models;
  using ooa_2_husrum_ef.Utils.Extensions;
  using System;
  using System.Collections.Generic;
  using System.Text;

  class COutTags : IConsoleOutputEntities
  {
    private List<Tag> Tags { get; set; }
    public COutTags(List<Tag> tags)
    {
      Tags = tags;
    }
    public void Write(string header)
    {
      Tags.Write(header);
    }
  }
}
