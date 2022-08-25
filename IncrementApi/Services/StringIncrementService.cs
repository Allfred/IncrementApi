using System.Text;
using System.Text.RegularExpressions;

namespace IncrementApi.Services;

public class StringIncrementService
{
    public string Increment(string str, int increment)
    {
        var result = new StringBuilder(str);
        var rg = new Regex(@"(0)|[1-9]\d*",RegexOptions.Multiline);
        var matchedAuthors = rg.Matches(str);

        foreach (Match item in matchedAuthors)
        {
            if (int.TryParse(item.Value, out var value))
            {
                value += increment;
                
                var dif = IntLength(value) - item.Length;
                
                if (dif!=0)
                {
                    value /= dif * 10;
                }

                result = result.Replace(item.Value, value.ToString(), item.Index, item.Length);

            }
        }
        
        return result.ToString();
    }
    
    private int IntLength(int i)
    {
        if (i < 0)
            throw new ArgumentOutOfRangeException();
        if (i == 0)
            return 1;
        return (int)Math.Floor(Math.Log10(i)) + 1;
    }
}