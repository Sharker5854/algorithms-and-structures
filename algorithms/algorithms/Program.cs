using algorithms;

// --- Работа со стеком --- //

var st = new algorithms.Stack();
Console.WriteLine(st.Show());
st.Push(777);
Console.WriteLine(st.Show());
st.Push(69);
st.Push(1337);
Console.WriteLine(st.Show());
Console.WriteLine(st.Pop().Value);
Console.WriteLine(st.Show());
Console.WriteLine(st.Pop().Value);
Console.WriteLine(st.Show());
Console.WriteLine(st.Pop().Value);
Console.WriteLine(st.Show());
Console.WriteLine("\n\n\n");

// --- Сортировка --- //

int[] arr = new int[] { 5, 0, 1, 37, 88, -12, -1000, 25 };
Console.WriteLine("До сортировки: ");
foreach (int i in arr) { Console.Write(i + " "); }
SimpleChoice sc = new SimpleChoice(arr);
Console.WriteLine("\nПосле сортировки: ");
foreach (int i in sc.Sort()) { Console.Write(i + " "); }
Console.WriteLine("\n\n\n");