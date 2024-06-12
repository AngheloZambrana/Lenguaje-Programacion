using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeraAplicacion
{
    static class Extensions
    {
        public static int GetCount<T>(this IEnumerable<T> collection)
        {
            return collection.Aggregate(0, (i, _) => i + 1);
        }
        
        public static string GetString<T>(this IEnumerable<T> collection)   
        {
            return collection.Aggregate("", (current, item) => current + item);
        }

        public static IEnumerable<T> GetReverse<T>(this IEnumerable<T> list)
        {
            return list.Aggregate(new List<T>(), (reversedList, item) => 
            {
                reversedList.Insert(0, item);
                return reversedList;
            });
        }
        
        public static string GetReverseString<T>(this IEnumerable<T> list)
        {
            return list.GetReverse().GetString();
        }

        public static T GetElementAt<T>(this IEnumerable<T> list, int index)
        {
            return list.Aggregate((current, item) =>
            {
                if (index == 0)
                    return current;

                return item;
            });
        }
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<TResult> GetNew<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Aggregate(new List<TResult>(), (newList, item) =>
            {
                var newItem = selector(item);
                newList.Add(newItem);
                return newList;
            });
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string text = "Hola mundo";
            List<int> numbers = new List<int>(){1,2,3,4,5,6,7,8,9,10};
            Predicate<int> evenPredicate = (x) => x % 2 == 0;
            var evenNumbers = numbers.Filter(evenPredicate);
        
            
            Console.WriteLine(text.GetCount() == 10);
            Console.WriteLine(numbers.GetCount() == 10);
            Console.WriteLine(text.GetString() == "Hola mundo");
            Console.WriteLine(numbers.GetString() == "12345678910");
            Console.WriteLine(numbers.GetReverseString() == "10987654321");
            Console.WriteLine(text.GetReverseString() == "odnum aloH");
            Console.WriteLine(numbers.GetElementAt(0) == 1);
            Console.WriteLine(text.GetElementAt(0) == 'H');
            foreach (var item in evenNumbers)
            {
                Console.WriteLine(item);
            }
            var names = new List<string>() { "Alice", "Bob", "Charlie" };
            var counts = names.GetNew(name => name.GetCount());

            foreach (var count in counts)
            {
                Console.WriteLine(count);
            }

        }
    }
}
        
