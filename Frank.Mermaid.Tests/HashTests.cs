using System.Text;

namespace Frank.Mermaid.Tests;

public class HashTests
{
    private readonly ITestOutputHelper _outputHelper;

    public HashTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }


    [Fact]
    public void GenerateHash_WithZeroTicksDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime dateTime = new DateTime(0L, DateTimeKind.Utc);
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateHash_WithCurrentDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime dateTime = DateTime.UtcNow;
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateHash_WithSpecificDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime dateTime = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateHash_WithMaxDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime dateTime = DateTime.MaxValue;
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateHash_WithMinDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime dateTime = DateTime.MinValue;
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateHash_WithNullDateTime_ReturnsValidBase36Hash()
    {
        // Arrange
        DateTime? dateTime = null;
        var hash = new Hash(dateTime);

        // Act
        var result = hash.ToString();

        // Assert
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void GenerateMultipleHashes_SortsByDateTime()
    {
        // Arrange
        var hashes = new List<Hash>
        {
            new Hash(DateTime.MinValue),
            new Hash(DateTime.MaxValue),
            new Hash(),
            new Hash(DateTime.Today),
            Hash.Parse("000000000069"),
            Hash.Parse(Hash.Parse("000000000666").ToInt64()),
            new Hash(new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 2, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 3, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 4, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 5, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 6, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 7, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 8, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 9, 0, 0, 0, DateTimeKind.Utc)),
            new Hash(new DateTime(2022, 1, 10, 0, 0, 0, DateTimeKind.Utc)),
        }.Order().ToList();

        // Act
        var result = hashes.Select(x => x.ToString()).Order().ToList();

        // Assert
        _outputHelper.WriteLine("Expected:      Actual:        Result:   DateTime:");
        for (var index = 0; index < result.Count; index++)
        {
            var hashResult = result[index];
            var hashSource = hashes[index].ToString();
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(hashSource);
            stringBuilder.Append("   ");
            stringBuilder.Append(hashResult);
            stringBuilder.Append("   ");
            stringBuilder.Append(hashSource == hashResult);
            stringBuilder.Append("      ");
            
            var step1 = hashes[index];
            var step2 = step1.ToInt64();
            var step3 = new DateTime(step2);
            
            stringBuilder.Append($"{step3:s}");
            var comparisonString = stringBuilder.ToString();
            
            _outputHelper.WriteLine(comparisonString);
            Assert.Equal(hashSource, hashResult);
        }

        Assert.Equal(hashes.Count, result.Count);
    }
}