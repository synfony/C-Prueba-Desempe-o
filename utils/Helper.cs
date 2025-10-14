public static class Helper
{
    public static string ReadNonEmptyLine(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("⚠️ Por favor, ingrese un valor válido.");
        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    public static byte ReadByte(string prompt)
    {
        byte value;
        while (true)
        {
            string input = ReadNonEmptyLine(prompt);
            if (byte.TryParse(input, out value))
                return value;
            Console.WriteLine("⚠️ Ingrese un número válido (0-255).");
        }

    }

    public static class ValidationHelper
{
    public static bool IsDocumentDuplicate<T>(List<T> list, string document) where T : Person
    {
        bool exists = list.Any(item => item.Document == document);

        if (exists)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ el documento ya esta registrado.");
            Console.ResetColor();
        }

        return exists;
    }

    public static bool IsValidEmail(string email)
    {
        bool isValid = email.Contains("@") && email.Contains(".");
        if (!isValid)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ email invalido, debe de tener '@'");
            Console.ResetColor();
        }

        return isValid;
    }

    public static bool IsValidPhone(string phone)
    {
        bool isValid = phone.All(char.IsDigit) && phone.Length >= 7;
        if (!isValid)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠️ Numero de telefono invalido, debe de tener 7 numeros al menos");
            Console.ResetColor();
        }

        return isValid;
    }
}
    
}
