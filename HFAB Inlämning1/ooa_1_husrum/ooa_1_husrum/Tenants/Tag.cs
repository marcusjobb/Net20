using System;

namespace ooa_1_husrum
{
  class Tag // TODO remove? doesn't seem useful
  {
    public string Id { get; private set; }
    public string Owner { get; private set; }
    public string[] Access { get; private set; }
    public DateTime Activate { get; private set; }
    public DateTime Expire { get; private set; }
    public Tag(Role role, string id, string owner)
    {
      Id = id;
      Owner = owner;
      Access = SetAccess(role);
    }
    public Tag(Role role, string id, string owner, DateTime activate, DateTime expire)
    {
      Id = id;
      Owner = owner;
      Access = SetAccess(role);
      Activate = activate;
      Expire = expire;
    }

    private string[] SetAccess(Role role)
    {
      throw new Exception("Not yet implemented."); // TODO

      switch (role)
      {
        case Role.Caretaker: // access to all
          // TODO
          break;
        case Role.Tenant: // access to apartment doors, ut, soprum, tvättrum
          // TODO
          break;
      }
    }
    public override string ToString()
    {
      string AccessToString(string[] access)
      {
        string accesses = "";
        foreach (string door in access)
        {
          accesses += door + ", ";
        }
        accesses = accesses.TrimEnd();
        accesses = accesses.TrimEnd(',');
        return accesses;
      }
      return $"Tag: {Id}, Owner: {Owner}, Access: {AccessToString(Access)}, {(Activate != DateTime.MinValue ? "Activate: " + Activate + "," : "")} {(Expire != DateTime.MinValue ? "Expires: " + Expire + "," : "")},";
    }
  }
}
