public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

       // --- PLAN ---
        // 1. Crear un nuevo arreglo de números tipo 'double' con el tamaño definido por el parámetro 'length'.
        // 2. Crear un ciclo (for) que se repita tantas veces como indique 'length', usando un índice que empiece en 0.
        // 3. En cada iteración, calcular el múltiplo correspondiente multiplicando el 'number' original por (índice + 1).
        // 4. Guardar el resultado del cálculo en la posición actual del arreglo.
        // 5. Una vez terminado el ciclo, retornar el arreglo con todos los múltiplos.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
   // --- PLAN ---
        // 1. Calcular el índice de inicio desde donde se va a cortar la parte final de la lista. 
        //    Esto se logra restando el 'amount' al total de elementos (data.Count).
        // 2. Obtener la sección de la lista que se moverá al frente utilizando 'GetRange', iniciando 
        //    desde el índice calculado en el paso anterior hasta el final de la lista.
        // 3. Remover esa misma sección de la lista original usando 'RemoveRange' para que no quede duplicada atrás.
        // 4. Insertar la sección guardada al principio de la lista original (en el índice 0) usando 'InsertRange'.

        int splitIndex = data.Count - amount;

        List<int> partToMove = data.GetRange(splitIndex, amount);

        data.RemoveRange(splitIndex, amount);

        data.InsertRange(0, partToMove);
    }
}
