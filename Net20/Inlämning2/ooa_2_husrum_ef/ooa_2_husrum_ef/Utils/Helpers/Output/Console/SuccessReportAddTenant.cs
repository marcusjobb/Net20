namespace ooa_2_husrum_ef.Utils.Helpers.Output.Console
{
  using ooa_2_husrum_ef.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Text;

  class SuccessReportAddTenant : IConsoleOutput
  { 
    private bool Result { get; set; }
    public SuccessReportAddTenant(bool result)
    {
      Result = result;
    }

    public void Write()
    {
      Console.WriteLine(
        "Add tenant " + (Result ? "was a success!" : "failed.")
        );
    }

   
  }
}
