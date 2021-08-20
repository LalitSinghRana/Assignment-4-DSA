using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEx1
{
    class HashTable<TKey, TValue> 
    {
        internal class HashTableEntry
        {
            internal HashTableEntry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            internal TKey Key;
            internal TValue Value;
            internal HashTableEntry Next;
        }

        HashTableEntry[] table = new HashTableEntry[4];

        private int GetHash(TKey key) 
        {
            var hash = key.GetHashCode();
            return hash < 0 ? hash*-1 : hash;
        }

        private int GetIndex(TKey key) {
            return GetHash(key) % table.Length;
        }

        public void Insert(TKey key, TValue value)
        {
            if (this.Contains(key)) throw new Exception("Key already exists");

            if ((float)Size/table.Length >= 0.8)
            {
                HashTableEntry[] oldTable = table;
                table = new HashTableEntry[oldTable.Length * 2];
                foreach(var oe in oldTable)
                {
                    if (oe == null) continue;
                    var x = oe.Next;
                    while(x!=null)
                    {
                        var i = GetIndex(x.Key);
                        var e = new HashTableEntry(x.Key, x.Value);
                        if (table[i] == null)
                        {
                            table[i] = new HashTableEntry(default, default);
                            //table[i].Next = e;
                        }
                        var current = table[i];
                        while (current.Next != null) current = current.Next;
                        current.Next = e;

                        x = x.Next;
                    }
                }
            }
            
            var index = GetIndex(key);
            var element = new HashTableEntry(key, value);
            if (table[index] == null)
            {
                table[index] = new HashTableEntry(default, default);
                table[index].Next = element;
            }
            else
            {
                var current = table[index];
                while (current.Next != null) current = current.Next;
                current.Next = element;
            }
            Size++;
        }

        public void Delete(TKey key)
        {
            if (this.Contains(key))
            {
                var index = GetIndex(key);

                var prevoius = table[index];
                if (prevoius != null)
                {
                    var current = prevoius.Next;
                    while (current != null)
                    {
                        if (current.Key.Equals(key))
                        {
                            prevoius.Next = current.Next;
                            break;
                        }
                        prevoius = current;
                        current = current.Next;
                    }
                }
                Size--;
                Console.WriteLine("{0} removed", key);
            }
            else
            {
                Console.WriteLine("Invalid key {0}", key);
            }
            
        }

        public bool Contains(TKey key)
        {
            var index = GetIndex(key);

            var current = table[index];
            if(current != null)
            {
                current = current.Next;
                while (current != null)
                {
                    if (current.Key.Equals(key)) return true;
                    current = current.Next;
                }
            }
            
            return false;
        }

        public TValue GetValueByKey(TKey key)
        {
            var index = GetIndex(key);
            var current = table[index];
            if (current != null)
            {
                current = current.Next;
                while (current != null)
                {
                    if (current.Key.Equals(key)) return current.Value;
                    current = current.Next;
                }
            }
            Console.WriteLine("Invalid Key {0}", key);
            return default; 
        }

        public IEnumerator<HashTableEntry> GetEnumerator()
        {
            foreach(var x in table)
            {
                if(x != null) yield return x.Next;
            }
        }

        public void Print()
        {
            foreach (var x in this)
            {
                var c = x;
                while (c != null)
                {
                    Console.Write(c.Value + "-> ");
                    c = c.Next;
                }
                Console.Write("null\n");
            }
        }

        public int Size { get; set; }
    }
}
