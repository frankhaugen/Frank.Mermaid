namespace Frank.Mermaid;

/// <summary>
/// Defines the functionality for a builder that supports indentation-sensitive string building.
/// </summary>
public interface IIndentedStringBuilder
{
    /// <summary>
    /// Increases the current indentation level by one step.
    /// </summary>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder IncreaseIndent();

    /// <summary>
    /// Decreases the current indentation level by one step, if it is greater than zero.
    /// </summary>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder DecreaseIndent();

    /// <summary>
    /// Appends the specified text to the current string without a newline.
    /// </summary>
    /// <param name="text">The text to append.</param>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder Write(string text);

    /// <summary>
    /// Appends the specified line of text to the current string with a newline.
    /// </summary>
    /// <param name="line">The line to append. If null, just appends a newline.</param>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder WriteLine(string line = "");

    /// <summary>
    /// Appends formatted text to the current string without a newline.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to format.</param>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder Write(string format, params object?[] args);

    /// <summary>
    /// Appends a formatted line of text to the current string with a newline.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="args">An array of objects to format.</param>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder WriteLine(string format, params object[] args);

    /// <summary>
    /// Appends the contents of another <see cref="IIndentedStringBuilder"/> instance to this builder, 
    /// preserving the indentation and adding new lines as needed.
    /// </summary>
    /// <param name="other">The other instance of IIndentedStringBuilder whose contents are to be appended.</param>
    /// <returns>The current instance of the builder for method chaining.</returns>
    IIndentedStringBuilder WriteLine(IIndentedStringBuilder other);
}