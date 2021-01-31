namespace ooa_2_husrum_ef.Utils.Helpers.Output.Console
{
  using ooa_2_husrum_ef.Interfaces;
  using System;
  using System.Collections.Generic;
  using System.Text;

  class SuccessReportMoveTenant : IConsoleOutput
  { 
    private bool Result { get; set; }
    public SuccessReportMoveTenant(bool result)
    {
      Result = result;
    }

    public void Write()
    {
      Console.WriteLine(
        "Move tenant " + (Result ? "was a success!" : "failed.")
        );
    }

   
  }
}
