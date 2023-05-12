using algorithms;


// --- Работа со стеком --- //

var st = new algorithms.Stack();

Console.WriteLine(st.Show());        // HEAD -> {  }
st.Push(777);
st.Push(404);
st.Push(666);
st.Push(69);
st.Push(1337);
Console.WriteLine(st.Show());        // HEAD -> { 1337, 69, 666, 404, 777 }

Console.WriteLine(st[1]);            // 69
// Console.WriteLine(st[5]);         // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
// Console.WriteLine(st[-1]);        // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*

st[3] = 102;
st[0] = 228;
st[7] = 13;
// st[9] = 911;                      // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
// st[-1] = 101;                     // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
Console.WriteLine(st.Show());        // HEAD-> { 228, 1337, 69, 666, 102, 404, 777, 13 }

Console.WriteLine(st.Pop().Value);   // 228
Console.WriteLine(st.Pop().Value);   // 1337
Console.WriteLine(st.Pop().Value);   // 69
Console.WriteLine(st.Pop().Value);   // 666
Console.WriteLine(st.Pop().Value);   // 102
Console.WriteLine(st.Pop().Value);   // 404
Console.WriteLine(st.Pop().Value);   // 777
Console.WriteLine(st.Pop().Value);   // 13
//Console.WriteLine(st.Pop().Value); // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ, Т.К. СТЕК ПУСТОЙ*
Console.WriteLine(st.Show());        // HEAD -> {  }
Console.WriteLine("\n\n\n");



// --- Сортировка --- //

Stack stack = new Stack();
stack.Push(25); stack.Push(-1000); stack.Push(88); stack.Push(-1); stack.Push(0); stack.Push(5); stack.Push(1);
Console.WriteLine("До сортировки: ");
Console.WriteLine(stack.Show());              //   HEAD -> { 1, 5, 0, -1, 88, -1000, 25 }
SimpleChoice sc = new SimpleChoice(stack);
Console.WriteLine("\nПосле сортировки: ");
Console.WriteLine(sc.Sort().Show());          //   HEAD -> { -1000, -1, 0, 1, 5, 25, 88 }
Console.WriteLine("\n\n\n");
