using System;
using System.Collections.Generic;
using System.Text;

namespace ooa_1_husrum
{
  class TenantsManager // TODO remove
  {
    private DBHandler DBH { get; set; }
    public TenantsManager(DBHandler dbh)
    {
      throw new Exception("Not yet implemented."); // TODO
    }
    public void NewLocation(string location, params string[] doors)
    {
      throw new Exception("Not yet implemented."); // TODO
    }
    public void NewTenant(string name, string apartment)
    {
      throw new Exception("Not yet implemented."); // TODO
      Tag tag = NewTag(name);
    }
    public void TenantMovesOut(string tenantId)
    {
      throw new Exception("Not yet implemented."); // TODO
    }
    private Tag NewTag(string owner)
    {
      throw new Exception("Not yet implemented."); // TODO
    }
    private void ExpireTag(string tag)
    {
      throw new Exception("Not yet implemented."); // TODO
    }
  }
}
