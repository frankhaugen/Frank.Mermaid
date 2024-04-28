using System.Diagnostics;
using System.Text;

namespace Frank.Mermaid;

[DebuggerDisplay("{ToString()}")]
public readonly struct Hash : IEquatable<Hash>, IComparable<Hash>
{
    private const string Base36Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int Base36Length = 12;
    
    private readonly long _ticks;

    /// <summary>
    /// Creates a new GitHash with the current date and time as a seed.
    /// </summary>
    public Hash() => _ticks = GetTicks();

    /// <summary>
    /// Creates a new GitHash with the current or the provided date and time as a seed.
    /// </summary>
    /// <param name="dateTime"></param>
    public Hash(DateTime? dateTime = null)
    {
        _ticks = GetTicks(dateTime ?? DateTime.UtcNow);
    }
    
    public static Hash Parse(string base36) => Parse(FromBase36(base36));
    
    public static Hash Parse(long value) => new(DateTime.FromBinary(value));
    
    public static Hash NewHash() => new();

    private static long GetTicks(DateTime? dateTime = null)
    {
        var tics = dateTime?.Ticks ?? (DateTime.UtcNow.Ticks + Random.Shared.NextInt64(1000, 5000));
        
        if (tics < 0) 
            throw new ArgumentOutOfRangeException(nameof(dateTime), "ticks must be greater than 0 or equal to 0, actual value: " + tics.ToString("D"));
        
        return tics;
    }
    
    private static long FromBase36(string base36)
    {
        if (string.IsNullOrEmpty(base36))
            throw new ArgumentException("Input string is null or empty.");

        long result = 0;
        long multiplier = 1;
        for (int i = base36.Length - 1; i >= 0; i--)
        {
            char c = base36[i];
            int value = Base36Chars.IndexOf(c);
            if (value == -1 || value >= 36)
                throw new ArgumentException($"Invalid character '{c}' in Base36 string.");

            result += value * multiplier;
            multiplier *= 36;
        }

        return result;
    }
    
    private static string ToBase36(long value)
    {
        if (value == 0) return "0";

        var result = new StringBuilder();
        while (value > 0)
        {
            result.Insert(0, Base36Chars[(int)(value % 36)]);
            value /= 36;
        }
        return result.ToString();
    }
    
    public long ToInt64() => _ticks;

    /// <summary>
    /// Returns a Base36 string representation of the underlying long.
    /// </summary>
    public override string ToString()
    {
        var hashString = ToBase36(_ticks);
        
        if (hashString.Length < Base36Length) 
            hashString = hashString.PadLeft(Base36Length, '0');
        if (hashString.Length > Base36Length) 
            hashString = hashString.Substring(0, Base36Length);
        
        return hashString;
    }

    /// <inheritdoc />
    public bool Equals(Hash other) => _ticks == other._ticks;

    /// <inheritdoc />
    public int CompareTo(Hash other) => _ticks < other._ticks ? -1 : _ticks > other._ticks ? 1 : 0;

    public override bool Equals(object? obj) => obj is Hash other && _ticks == other._ticks;
    public override int GetHashCode() => _ticks.GetHashCode();
    
    public static bool operator ==(Hash a, Hash b) => a._ticks == b._ticks;
    public static bool operator !=(Hash a, Hash b) => a._ticks != b._ticks;
    public static bool operator <(Hash a, Hash b) => a._ticks < b._ticks;
    public static bool operator >(Hash a, Hash b) => a._ticks > b._ticks;
    public static bool operator <=(Hash a, Hash b) => a._ticks <= b._ticks;
    public static bool operator >=(Hash a, Hash b) => a._ticks >= b._ticks;
}