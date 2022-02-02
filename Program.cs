public class Program
{
    public static void Main(string[] args)
    {
        //string text = "//;\n1;2";
        Console.WriteLine(add("//***\n1***2***3"));
        Console.WriteLine(bracketdDelimeter("//[*][%]\n1*2%3"));
    }

    static int add(string numbers) 
    {
        int sum = 0;
        string delimiter ="";
        bool isInt = false;
        string[] delimiters;

        if (numbers != "") 
        {
            delimiters = new string[] { ",", "\n"};
            //Adding sugested delimiter
            if (numbers.Trim().Substring(0,2) == "//") 
            {
                delimiter = numbers.Substring(2, 1);
                if (delimiter == "*") 
                {
                    delimiter = extendedDelimeter(numbers);
                }
                delimiters = new string[] { ",", "\n", delimiter };
                if (delimiter == "[") 
                { 
                  
                }
            }
            //Split an array with multiply delimeters
              
            string[] numbersArray = numbers.Split(delimiters,StringSplitOptions.None);

            for (int i = 0; i < numbersArray.Length; i++)
            {
                //Check wheather the array item is a number or integer
                isInt = int.TryParse(numbersArray[i], out int num);
                if (isInt == true) 
                {
                    //Validating array items greater than 1000
                    if (Convert.ToInt16(numbersArray[i]) > 1000)
                    { 
                       i++;
                    }
                    //Exception handling throw when an array item is less than 0
                    if (Convert.ToInt16(numbersArray[i]) < 0)
                    {
                        throw new ArithmeticException(throwEx(numbersArray));
                    }
                    sum += Convert.ToInt16(numbersArray[i]);
                }
            }
            return sum;
        }
        return 0;
    }

    //Method that returns exception message
    static string throwEx(string[] arrayofNumbers)
    {
        string negetives = "Negatives not allowed.";
        foreach (var item in arrayofNumbers) 
        {
            if (Convert.ToInt16(item) < 0) 
            {
                negetives += "\n" + item;
            }
        }
        return negetives;
    }

    //Method that forms a **** delimeter with any length
    static string extendedDelimeter(string numbers) 
    {
        string delimeter = "";
        char[] characterArray = numbers.ToCharArray();
        for (int x = 2; x<characterArray.Length-1; x++) 
        {
            if (characterArray[x] == '*') {
                delimeter += "*";
            }
            break;
        }
        return delimeter;
    }
    static string bracketdDelimeter(string numbers)
    {
        string  delimeter = "";
        int index = numbers.LastIndexOf("]");
        delimeter = numbers.Substring(3, index - 3).Replace("]","");
        delimeter = delimeter.Replace("[", "");
        return delimeter;
    }
}