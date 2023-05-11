using algorithms;


// --- Работа со стеком --- //

var st = new algorithms.Stack();

Console.WriteLine(st.Show());        // HEAD -> {  }
st.Push(777);
st.Push(69);
st.Push(1337);
Console.WriteLine(st.Show());        // HEAD -> { 1337, 69, 777 }

Console.WriteLine(st[1]);            // 69
// Console.WriteLine(st[5]);         // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
// Console.WriteLine(st[-1]);        // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*

st[1] = 666;
Console.WriteLine(st[1]);            // 666
// Console.WriteLine(st[-1]);        // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
// Console.WriteLine(st[4]);         // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
Console.WriteLine(st.Show());        // HEAD-> { 1337, 666, 69, 777 }

Console.WriteLine(st.Pop().Value);   // 1337
Console.WriteLine(st.Pop().Value);   // 666
Console.WriteLine(st.Pop().Value);   // 69
Console.WriteLine(st.Pop().Value);   // 777
Console.WriteLine(st.Show());        // HEAD -> {  }
Console.WriteLine("\n\n\n");



// --- Сортировка --- //

int[] arr = new int[] { 5, 0, 1, 37, 88, -12, -1000, 25 };
Console.WriteLine("До сортировки: ");
foreach (int i in arr) { Console.Write(i + " "); }              //   5 0 1 37 88 -12 -1000 25
SimpleChoice sc = new SimpleChoice(arr);
Console.WriteLine("\nПосле сортировки: ");
foreach (int i in sc.Sort()) { Console.Write(i + " "); }        //   -1000 -12 0 1 5 25 37 88
Console.WriteLine("\n\n\n");