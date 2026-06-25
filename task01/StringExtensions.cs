namespace task01;

public static class StringExtensions
{
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return false;

        // Убираем пробелы и знаки препинания вручную
        string cleaned = "";
        foreach (char c in input.ToLower())
        {
            if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
            {
                cleaned += c;
            }
        }

        if (string.IsNullOrEmpty(cleaned))
            return false;

        // Проверяем палиндром вручную
        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
}