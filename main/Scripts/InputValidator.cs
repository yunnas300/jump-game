public static bool ValidateGameResult(string result)
{
    return int.TryParse(result, out _);
}

if (!InputValidator.ValidateGameResult(userInput))
{
    throw new ArgumentException("Invalid game result format!");
}