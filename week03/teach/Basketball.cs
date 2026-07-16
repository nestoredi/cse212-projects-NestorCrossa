/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
       while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            
            // Validar que el campo de puntos no esté vacío antes de convertirlo
            var points = string.IsNullOrEmpty(fields[8]) ? 0 : int.Parse(fields[8]);

            // --- PASO 1: Agregar o actualizar los puntos del jugador en el mapa ---
            if (players.ContainsKey(playerId)) {
                players[playerId] += points;
            } else {
                players[playerId] = points;
            }
        }

        // --- PASO 2: Ordenar y obtener los 10 mejores ---
        // Convertimos el diccionario en una lista/matriz ordenada de forma descendente por el valor (puntos)
        var sortedPlayers = players.OrderByDescending(pair => pair.Value).Take(10).ToArray();

        // --- PASO 3: Mostrar los resultados en una tabla ---
        Console.WriteLine("\n--- TOP 10 PLAYERS BY CAREER POINTS ---");
        Console.WriteLine(string.Format("{0,-15} | {1,-10}", "Player ID", "Total Points"));
        Console.WriteLine(new string('-', 30));

        foreach (var player in sortedPlayers)
        {
            Console.WriteLine(string.Format("{0,-15} | {1,-10:N0}", player.Key, player.Value));
        }
    }
}