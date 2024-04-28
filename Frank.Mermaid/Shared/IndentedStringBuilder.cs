using System.Text;

namespace Frank.Mermaid;

public class IndentedStringBuilder : IIndentedStringBuilder
{
	private StringBuilder _builder = new StringBuilder();
	private int _indentLevel = 0;
	private readonly string _indentString;

	public IndentedStringBuilder(string indentString = "    ")  // Default to 4 spaces
	{
		_indentString = indentString;
	}

	public IIndentedStringBuilder IncreaseIndent()
	{
		_indentLevel++;
		return this;
	}

	public IIndentedStringBuilder DecreaseIndent()
	{
		if (_indentLevel > 0)
			_indentLevel--;
		return this;
	}

	public IIndentedStringBuilder Write(string text)
	{
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.Append(text);
		return this;
	}

	public IIndentedStringBuilder WriteLine(string line = "")
	{
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.AppendLine(line);
		return this;
	}

	public IIndentedStringBuilder Write(string format, params object[] args)
	{
		string formattedText = string.Format(format, args);
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.Append(formattedText);
		return this;
	}

	public IIndentedStringBuilder WriteLine(string format, params object[] args)
	{
		string formattedText = string.Format(format, args);
		_builder.Append(new String(_indentString[0], _indentLevel * _indentString.Length));
		_builder.AppendLine(formattedText);
		return this;
	}

	public IIndentedStringBuilder WriteLine(IIndentedStringBuilder other)
	{
		if (other is IndentedStringBuilder otherBuilder)
		{
			string[] lines = otherBuilder.ToString().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (var line in lines.Where(l => l.Any()))
			{
				this.WriteLine(line);
			}
		}
		return this;
	}

	public override string ToString()
	{
		return _builder.ToString();
	}
}