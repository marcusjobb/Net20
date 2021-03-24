public class Algorithms
{
    // En algoritm som tar emot två nummer och returnerar summan
    // Om nummrerna är lika med varandra returnera summan gånger tre
    public static int Alg1(int num1, int num2)
    {
        var sum = num1 + num2;
        return num1 == num2 ? sum * 3 : sum;
    }

    // En algoritm som tar emot en sträng och returnerar
    // fyra kopior av de två första bokstäverna från den givna strängen
    public static string Alg2(string str)
    {
        var copy = "";
        for (var i = 0; i < 4; i++)
        {
            copy += str.Substring(0, 2);
        }

        return copy;
    }

    // En algoritm som tar emot en sträng och returnerar första och sista bokstaven
    public static string Alg3(string str)
    {
        return str[0] + ", " + str[str.Length - 1];
    }

    // En algoritm som kollar om ett nummer är jämnt delbar med 7 eller 13
    public static bool Alg4(int num)
    {
        return num % 7 == 0 || num % 13 == 0;
    }

    // En algoritm som kollar om ett nummer är ett primtal eller inte
    public static bool Alg5(int num)
    {
        if (num <= 1) return false;

        // kollar om num är jämnt delbar med nummer mellan 2 och num - 1
        for (var i = 2; i < num; i++)
        {
            if (num % i == 0) return false;
        }

        return true;
    }

    // En algoritm som tar emot en array av nummer och gör om denna till en sträng med alla nummer
    // Den ersätter alla nummer som är jämnt delbart med 3 eller 5 med fizz och buzz
    public static string Alg6(int[] arr)
    {
        var str = "";
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 3 == 0) str += "Fizz";
            if (arr[i] % 5 == 0) str += "Buzz";
            if (arr[i] % 3 != 0 && arr[i] % 5 != 0) str += i;
        }

        return str;
    }
}