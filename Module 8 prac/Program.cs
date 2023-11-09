// нужно отдельно проверять каждый пример

using System;
using System.Collections.Generic;

class ArrayWrapper
{
    private int[] array;

    public ArrayWrapper(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public void Resize(int newSize)
    {
        Array.Resize(ref array, newSize);
    }
}

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int columns)
    {
        matrix = new int[rows, columns];
    }

    public int this[int row, int column]
    {
        get { return matrix[row, column]; }
        set { matrix[row, column] = value; }
    }

    public static Matrix Add(Matrix m1, Matrix m2)
    {
        int rows = m1.matrix.GetLength(0);
        int columns = m1.matrix.GetLength(1);
        Matrix result = new Matrix(rows, columns);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }

        return result;
    }
}

class Dictionary
{
    private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

    public string this[string key]
    {
        get
        {
            if (keyValuePairs.ContainsKey(key))
            {
                return keyValuePairs[key];
            }
            else
            {
                return null;
            }
        }
        set { keyValuePairs[key] = value; }
    }

    public void Add(string key, string value)
    {
        keyValuePairs.Add(key, value);
    }

    public void Remove(string key)
    {
        keyValuePairs.Remove(key);
    }
}

class DataStorage
{
    private List<object> data = new List<object>();

    public object this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    public object this[string name]
    {
        get { return data.Find(item => item.GetType().Name == name); }
    }

    public void Add(object item)
    {
        data.Add(item);
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArrayWrapper arrayWrapper = new ArrayWrapper(5);
        arrayWrapper[0] = 1;
        arrayWrapper[1] = 2;
        arrayWrapper[2] = 3;
        arrayWrapper[3] = 4;
        arrayWrapper[4] = 5;
        Console.WriteLine(arrayWrapper[2]);
        arrayWrapper.Resize(10);
        Console.WriteLine(arrayWrapper[6]);

        Matrix matrix1 = new Matrix(2, 2);
        Matrix matrix2 = new Matrix(2, 2);
        matrix1[0, 0] = 1;
        matrix1[0, 1] = 2;
        matrix1[1, 0] = 3;
        matrix1[1, 1] = 4;
        matrix2[0, 0] = 5;
        matrix2[0, 1] = 6;
        matrix2[1, 0] = 7;
        matrix2[1, 1] = 8;
        Matrix sum = Matrix.Add(matrix1, matrix2);
        Console.WriteLine(sum[1, 1]);

        Dictionary dictionary = new Dictionary();
        dictionary.Add("one", "один");
        dictionary.Add("two", "два");
        Console.WriteLine(dictionary["one"]);
        dictionary["two"] = "две";
        Console.WriteLine(dictionary["two"]);
        dictionary.Remove("one");
        Console.WriteLine(dictionary["one"]);

        DataStorage storage = new DataStorage();
        storage.Add(42);
        storage.Add("Hello");
        storage.Add(new List<int> { 1, 2, 3 });
        Console.WriteLine(storage[0]);
        Console.WriteLine(storage["List`1"]);
    }
}
