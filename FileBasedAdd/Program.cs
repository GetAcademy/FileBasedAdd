
using FileBasedAdd;


var fileNamesResult = Logic.GetArgs(args);
if (!fileNamesResult.IsSuccess)
{
    Console.WriteLine(fileNamesResult.Error);
    return 1;
}

var sumResult =
    Logic.ReadFileAndParseIntAndAdd(fileNamesResult.Value.InputFile1)(0)
        .FlatMap(Logic.ReadFileAndParseIntAndAdd(fileNamesResult.Value.InputFile2))
        .FlatMap(Logic.SaveFile(fileNamesResult.Value.OutputFile));

if (!sumResult.IsSuccess)
{
    Console.WriteLine(sumResult.Error);
    return 1;
}

Console.WriteLine($"Skrev resultatet {sumResult.Value} til '{fileNamesResult.Value.OutputFile}'.");
return 0;


/*
 * Omskriving til Result
 */


//var fileNamesResult = Logic.GetArgs(args);
//if (!fileNamesResult.IsSuccess)
//{
//    Console.WriteLine(fileNamesResult.Error);
//    return 1;
//}

//var number1Result = Logic.ReadFileAndParseIntAndAdd(fileNamesResult.Value.InputFile1);
//var number2Result = Logic.ReadFileAndParseIntAndAdd(fileNamesResult.Value.InputFile2);
//if (!number1Result.IsSuccess)
//{
//    Console.WriteLine(number1Result.Error);
//    return 1;
//}

//if (!number2Result.IsSuccess)
//{
//    Console.WriteLine(number2Result.Error);
//    return 1;
//}

//int sum = number1Result.Value + number2Result.Value;

//var outputFile = fileNamesResult.Value.OutputFile;
//var saveFileResult = Logic.SaveFile(outputFile, sum);

//if (!saveFileResult.IsSuccess)
//{
//    Console.WriteLine(saveFileResult.Error);
//    return 1;
//}

//Console.WriteLine($"Skrev resultatet {saveFileResult.Value} til '{outputFile}'.");
//return 0;

/*
 * Opprinnelig versjon
 */

//if (args.Length != 3)
//{
//    Console.Error.WriteLine("Feil: Du må angi nøyaktig tre filnavn.");
//    Console.Error.WriteLine("Bruk: dotnet run <tallfil1> <tallfil2> <resultatfil>");
//    return 1;
//}

//string inputFile1 = args[0];
//string inputFile2 = args[1];
//string outputFile = args[2];

//int number1;
//int number2;

//try
//{
//    string text1 = File.ReadAllText(inputFile1).Trim();

//    if (!int.TryParse(text1, out number1))
//    {
//        Console.Error.WriteLine($"Feil: Innholdet i '{inputFile1}' er ikke et gyldig heltall.");
//        Console.Error.WriteLine($"Innhold: '{text1}'");
//        return 1;
//    }
//}
//catch (FileNotFoundException)
//{
//    Console.Error.WriteLine($"Feil: Fant ikke filen '{inputFile1}'.");
//    return 1;
//}
//catch (UnauthorizedAccessException)
//{
//    Console.Error.WriteLine($"Feil: Har ikke tilgang til å lese filen '{inputFile1}'.");
//    return 1;
//}
//catch (IOException ex)
//{
//    Console.Error.WriteLine($"Feil: Klarte ikke å lese filen '{inputFile1}'.");
//    Console.Error.WriteLine(ex.Message);
//    return 1;
//}

//try
//{
//    string text2 = File.ReadAllText(inputFile2).Trim();

//    if (!int.TryParse(text2, out number2))
//    {
//        Console.Error.WriteLine($"Feil: Innholdet i '{inputFile2}' er ikke et gyldig heltall.");
//        Console.Error.WriteLine($"Innhold: '{text2}'");
//        return 1;
//    }
//}
//catch (FileNotFoundException)
//{
//    Console.Error.WriteLine($"Feil: Fant ikke filen '{inputFile2}'.");
//    return 1;
//}
//catch (UnauthorizedAccessException)
//{
//    Console.Error.WriteLine($"Feil: Har ikke tilgang til å lese filen '{inputFile2}'.");
//    return 1;
//}
//catch (IOException ex)
//{
//    Console.Error.WriteLine($"Feil: Klarte ikke å lese filen '{inputFile2}'.");
//    Console.Error.WriteLine(ex.Message);
//    return 1;
//}

//int sum = number1 + number2;

//try
//{
//    if (File.Exists(outputFile))
//    {
//        Console.Error.WriteLine($"Feil: Utfilen '{outputFile}' finnes allerede.");
//        return 1;
//    }

//    File.WriteAllText(outputFile, sum.ToString());

//    Console.WriteLine($"Skrev resultatet {sum} til '{outputFile}'.");
//    return 0;
//}
//catch (UnauthorizedAccessException)
//{
//    Console.Error.WriteLine($"Feil: Har ikke tilgang til å skrive til '{outputFile}'.");
//    return 1;
//}
//catch (DirectoryNotFoundException)
//{
//    Console.Error.WriteLine($"Feil: Mappen til '{outputFile}' finnes ikke.");
//    return 1;
//}
//catch (IOException ex)
//{
//    Console.Error.WriteLine($"Feil: Klarte ikke å skrive til '{outputFile}'.");
//    Console.Error.WriteLine(ex.Message);
//    return 1;
//}