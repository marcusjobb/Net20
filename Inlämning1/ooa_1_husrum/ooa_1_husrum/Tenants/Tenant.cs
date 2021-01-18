using System;

namespace ooa_1_husrum
{
  enum Role
  {
    Tenant,
    Caretaker,
  }
  class Tenant // TODO remove? doesn't seem useful for now
  {
    public Tag Tag { get; private set; }
    public Tenant(Tag tag, string name, string apartment)
    {
      // TODO
    }
  }
}
