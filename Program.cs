using System;

class Program
{
    /// <summary>
    /// A simple example of how to run and use the code.
    /// </summary>
    static void Main()
    {


        string[] sentences = {
            "Today is Sunday",
            "Today is not Monday",
            "Tomorrow is Tuesday",
            "Tomorrow isn’t Wednesday",

        };


        Filter filter = new Filter(sentences);

        List<string> final_list = filter.Get_Filtered_Sentences(new Or (new Var("a"),new Var("hello")));


foreach (string i in final_list) {
    Console.WriteLine(i);
}



    }
}
