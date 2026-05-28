namespace FileBasedAdd
{
    record FileNames(string InputFile1, string InputFile2, string OutputFile);

    internal class Logic
    {
        public static Result<FileNames> GetArgs(string[] args)
        {
            if (args.Length != 3)
            {
                return Result<FileNames>.Failure(
                    "Feil: Du må angi nøyaktig tre filnavn.\n" +
                    "Bruk: dotnet run <tallfil1> <tallfil2> <resultatfil>");
            }

            return Result<FileNames>.Success(
                new FileNames(
                    args[0], args[1], args[2]));
        }

        public static Func<int,Result<int>> ReadFileAndParseIntAndAdd(string fileName)
        {
            return (int total) =>
            {
                try
                {
                    string text1 = File.ReadAllText(fileName).Trim();

                    if (!int.TryParse(text1, out int number))
                    {
                        return Result<int>.Failure(
                            $"Feil: Innholdet i '{fileName}' er ikke et gyldig heltall.\n" +
                            $"Innhold: '{text1}'");
                    }

                    return Result<int>.Success(number + total);
                }
                catch (FileNotFoundException)
                {
                    return Result<int>.Failure($"Feil: Fant ikke filen '{fileName}'.");
                }
                catch (UnauthorizedAccessException)
                {
                    return Result<int>.Failure($"Feil: Har ikke tilgang til å lese filen '{fileName}'.");
                }
                catch (IOException ex)
                {
                    return Result<int>.Failure($"Feil: Klarte ikke å lese filen '{fileName}'.\n" + ex.Message);
                }
            };
        }

        /*
            public static Result<int> ReadFileAndParseIntAndAdd(string fileName)
           {
               try
               {
                   string text1 = File.ReadAllText(fileName).Trim();

                   if (!int.TryParse(text1, out int number))
                   {
                       return Result<int>.Failure(
                           $"Feil: Innholdet i '{fileName}' er ikke et gyldig heltall.\n" +
                           $"Innhold: '{text1}'");
                   }

                   return Result<int>.Success(number + total);
               }
               catch (FileNotFoundException)
               {
                   return Result<int>.Failure($"Feil: Fant ikke filen '{fileName}'.");
               }
               catch (UnauthorizedAccessException)
               {
                   return Result<int>.Failure($"Feil: Har ikke tilgang til å lese filen '{fileName}'.");
               }
               catch (IOException ex)
               {
                   return Result<int>.Failure($"Feil: Klarte ikke å lese filen '{fileName}'.\n" + ex.Message);
               }
           }         
         */

        public static Func<int,Result<int>> SaveFile(string fileName)
        {
            return (int number) =>
            {
                try
                {
                    if (File.Exists(fileName))
                    {
                        return Result<int>.Failure($"Feil: Utfilen '{fileName}' finnes allerede.");
                    }

                    File.WriteAllText(fileName, number.ToString());

                    return Result<int>.Success(number);
                }
                catch (UnauthorizedAccessException)
                {
                    return Result<int>.Failure($"Feil: Har ikke tilgang til å skrive til '{fileName}'.");
                }
                catch (DirectoryNotFoundException)
                {
                    return Result<int>.Failure($"Feil: Mappen til '{fileName}' finnes ikke.");
                }
                catch (IOException ex)
                {
                    return Result<int>.Failure($"Feil: Klarte ikke å skrive til '{fileName}'.\n" + ex.Message);
                }
            };
        }
        //public static Result<int> SaveFile(string fileName, int number)
        //{
        //    try
        //    {
        //        if (File.Exists(fileName))
        //        {
        //            return Result<int>.Failure($"Feil: Utfilen '{fileName}' finnes allerede.");
        //        }

        //        File.WriteAllText(fileName, number.ToString());

        //        return Result<int>.Success(number);
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        return Result<int>.Failure($"Feil: Har ikke tilgang til å skrive til '{fileName}'.");
        //    }
        //    catch (DirectoryNotFoundException)
        //    {
        //        return Result<int>.Failure($"Feil: Mappen til '{fileName}' finnes ikke.");
        //    }
        //    catch (IOException ex)
        //    {
        //        return Result<int>.Failure($"Feil: Klarte ikke å skrive til '{fileName}'.\n" + ex.Message);
        //    }
        //}
    }
}
