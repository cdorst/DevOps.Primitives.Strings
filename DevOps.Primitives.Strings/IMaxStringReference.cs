namespace DevOps.Primitives.Strings
{
    public interface IMaxStringReference
    {
        AsciiStringReference Hash { get; set; }
        int HashId { get; set; }
        string Value { get; set; }
    }
}
