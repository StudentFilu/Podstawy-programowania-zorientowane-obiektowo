using System;

class Program {
    static void Main() {
        while (true) {
            Console.WriteLine("\n1. Kalkulator, 2. Konwerter, 3. Średnia, 4. Wyjście");
            string wybor = Console.ReadLine();
            switch (wybor) {
                case "1": Kalkulator(); break;
                case "2": Konwerter(); break;
                case "3": Srednia(); break;
                case "4": return;
            }
        }
    }

    static void Kalkulator() {
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        string op = Console.ReadLine();
        switch (op) {
            case "+": Console.WriteLine(a + b); break;
            case "-": Console.WriteLine(a - b); break;
            case "*": Console.WriteLine(a * b); break;
            case "/": Console.WriteLine(b != 0 ? (a / b).ToString() : "Błąd"); break;
        }
    }

    static void Konwerter() {
        string typ = Console.ReadLine().ToUpper();
        double val = Convert.ToDouble(Console.ReadLine());
        if (typ == "C") Console.WriteLine($"{val}°C = {val * 1.8 + 32}°F");
        else Console.WriteLine($"{val}°F = {(val - 32) / 1.8:F2}°C");
    }

    static void Srednia() {
        int n = int.Parse(Console.ReadLine());
        double suma = 0;
        for (int i = 0; i < n; i++) suma += double.Parse(Console.ReadLine());
        double avg = suma / n;
        Console.WriteLine($"Średnia: {avg:F2}");
        Console.WriteLine(avg >= 3.0 ? "Uczeń zdał." : "Uczeń nie zdał.");
    }
}
