using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    internal class Bag
    {
        public readonly int maxWeight;
        public IEnumerable<Item> Items => _items;

        private readonly List<Item> _items;
        private int CurrentWeight => _items.Sum(item => item.Count);

        public Bag(int maxWeight)
        {
            if (maxWeight > 0)
            {
                this.maxWeight = maxWeight;
                _items = new List<Item>();
            }
            else
                throw new Exception(nameof(maxWeight) + " must be greater than zero");
        }

        public bool TryAddItem(string name, int count)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception(nameof(name) + " must not be empty");

            if (count <= 0)
                throw new Exception(nameof(count) + " must be greater than zero");

            if (CurrentWeight + count > maxWeight)
                return false;
            else
            {
                var targetItem = _items.FirstOrDefault(item => item.name == name);

                if (targetItem == null)
                    _items.Add(new Item(name, count));
                else
                    targetItem.Grow(count);

                return true;
            }
        }
    }

    internal class Item
    {
        public readonly string name;
        public int Count { get; private set; }

        public Item(string name, int count)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception(nameof(name) + " must not be empty");

            if (count <= 0)
                throw new Exception(nameof(count) + " must be greater than zero");

            this.name = name;
            Count = count;
        }

        public void Grow(int count)
        {
            if (count <= 0)
                throw new Exception(nameof(count) + " must be greater than zero");

            Count += count;
        }
    }
}
