using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasProjut2
{
    class Tree
    {
        public static void MainTree()
        {
            //BinaryTree class written by Jaco Ruit
            string nama1 = "Zetta";
            string nama2 = "Nanno";
            string nama3 = "Zxk";
            BinaryTree<string> namaOrang = new BinaryTree<string>(nama3);
            namaOrang.InsertItems<string>(nama1, nama2);
            foreach (string nama in namaOrang)
            {
                Console.WriteLine(nama);
            }
            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static void InsertItems<TItem>(this BinaryTree<TItem> tree, params TItem[] items) where TItem : IComparable<TItem>
        {
            foreach (TItem item in items)
            {
                tree.Insert(item);
            }
        }
    }

    public class BinaryTree<TItem> : IEnumerable<TItem> where TItem : IComparable<TItem>
    {
        public BinaryTree<TItem> LeftTree { get; private set; }
        public BinaryTree<TItem> RightTree { get; private set; }

        public TItem Node { get; private set; }

        public BinaryTree(TItem node)
        {
            this.Node = node;
        }

        public void Insert(TItem item)
        {
            if (this.Node.CompareTo(item) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new BinaryTree<TItem>(item);
                else
                    this.LeftTree.Insert(item);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new BinaryTree<TItem>(item);
                else
                    this.RightTree.Insert(item);
            }
        }

        System.Collections.Generic.IEnumerator<TItem> System.Collections.Generic.IEnumerable<TItem>.GetEnumerator()
        {
            if (this.LeftTree != null)
            {
                foreach (TItem item in this.LeftTree)
                {
                    yield return item;
                }
            }

            yield return this.Node;

            if (this.RightTree != null)
            {
                foreach (TItem item in this.RightTree)
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

