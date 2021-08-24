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
        internal class HashTableNode
        {
            internal HashTableNode(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
            internal TKey Key;
            internal TValue Value;
            internal HashTableNode Next;
        }

        HashTableNode[] hashTableList = new HashTableNode[4];

        private int GetIndex(TKey key) {
            var hashCode = key.GetHashCode();
            hashCode = hashCode > 0 ? hashCode : -hashCode;
            return hashCode % hashTableList.Length;
        }

        public void Insert(TKey key, TValue value)
        {
            if (this.Contains(key)) throw new Exception("Key already exists");

            if ((float)Size/hashTableList.Length >= 0.8)
            {
                HashTableNode[] oldHashTableList = hashTableList;
                hashTableList = new HashTableNode[oldHashTableList.Length * 2];
                foreach(var hashTableEntry in oldHashTableList)
                {
                    if (hashTableEntry == null) continue;
                    var node = hashTableEntry.Next;
                    while(node!=null)
                    {
                        var newIndex = GetIndex(node.Key);
                        var newElement = new HashTableNode(node.Key, node.Value);
                        if (hashTableList[newIndex] == null)
                        {
                            hashTableList[newIndex] = new HashTableNode(default, default);
                        }
                        var current = hashTableList[newIndex];
                        while (current.Next != null) current = current.Next;
                        current.Next = newElement;

                        node = node.Next;
                    }
                }
            }
            
            var index = GetIndex(key);
            var element = new HashTableNode(key, value);
            if (hashTableList[index] == null)
            {
                hashTableList[index] = new HashTableNode(default, default);
                hashTableList[index].Next = element;
            }
            else
            {
                var current = hashTableList[index];
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

                var hashTableEntry = hashTableList[index];
                if (hashTableEntry != null)
                {
                    var previousNode = hashTableEntry;
                    var currentNode = previousNode.Next;
                    while (currentNode != null)
                    {
                        if (currentNode.Key.Equals(key))
                        {
                            previousNode.Next = currentNode.Next;
                            break;
                        }
                        previousNode = currentNode;
                        currentNode = currentNode.Next;
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

            var hashTableEntry = hashTableList[index];
            if(hashTableEntry != null)
            {
                var currentNode = hashTableEntry.Next;
                while (currentNode != null)
                {
                    if (currentNode.Key.Equals(key)) return true;
                    currentNode = currentNode.Next;
                }
            }
            
            return false;
        }

        public TValue GetValueByKey(TKey key)
        {
            if(this.Contains(key))
            {
                var index = GetIndex(key);
                var currentNode = hashTableList[index].Next;

                while (currentNode != null)
                {
                    if (currentNode.Key.Equals(key)) return currentNode.Value;
                    currentNode = currentNode.Next;
                }
            }
            Console.WriteLine("Invalid Key {0}", key);
            return default;
        }

        public IEnumerator<HashTableNode> GetEnumerator()
        {
            foreach(var hashTableEntry in hashTableList)
            {
                if(hashTableEntry != null) yield return hashTableEntry.Next;
            }
        }

        public void Print()
        {
            foreach (var headNode in this)
            {
                var currentNode = headNode;
                while (currentNode != null)
                {
                    Console.Write(currentNode.Value + "-> ");
                    currentNode = currentNode.Next;
                }
                Console.Write("null\n");
            }
        }

        public int Size { get; private set; }
    }
}
