using algorithms;


// --- Работа со стеком --- //

var st = new algorithms.Stack();

Console.WriteLine(st.Show());        // HEAD -> {  }
st.Push(777);
st.Push(111);
st.Push(333);
st.Push(333);
st.Push(69);
st.Push(1337);
Console.WriteLine(st.Show());        // HEAD -> { 1337, 69, 777 }

Console.WriteLine(st[1]);            // 69
// Console.WriteLine(st[5]);         // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*
// Console.WriteLine(st[-1]);        // *ВЫЛЕТИТ ИСКЛЮЧЕНИЕ*

st[2] = 666;
//st[4] = 0;
Console.WriteLine(st.Show());         // 666

st[4] = 222;
Console.WriteLine(st.Show());
st[8] = 444;
st[0] = 0;
Console.WriteLine(st.Show());
Console.WriteLine(st[3]);
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
/*
Stack stack = new Stack();
stack.Push(25); stack.Push(-1000); stack.Push(88); stack.Push(-1); stack.Push(0); stack.Push(5); stack.Push(1);
Console.WriteLine("До сортировки: ");
Console.WriteLine(stack.Show().Substring(8));              //   5 0 1 37 88 -12 -1000 25
SimpleChoice sc = new SimpleChoice(stack);
Console.WriteLine("\nПосле сортировки: ");
Console.WriteLine(sc.Sort().Show().Substring(8));        //   -1000 -12 0 1 5 25 37 88
Console.WriteLine("\n\n\n");
*/