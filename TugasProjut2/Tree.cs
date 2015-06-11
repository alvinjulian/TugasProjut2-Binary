using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TugasProjut2
{
    class Tree
    {

        public void cetakTree()
        {
            foreach (string namaanak in namaOrang)
            {
                Console.WriteLine(namaanak);
            }
            Console.ReadLine();
        }

        public BinaryTree<string> namaOrang;
        public void insertTree(string nama)
        {
            //BinaryTree class written by Jaco Ruit
            namaOrang.InsertItems<string>(nama);
        }

        public string root()
        {
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            StreamReader sr = new StreamReader(file);
            int a = 0;
            while ((line = sr.ReadLine()) != null &&a==0)
            {

                string[] result = rgx.Split(line);
                if (a == 0)
                    return result[0];
            }
            return "a";
        }
        public void bacaAll()
        {

            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            StreamReader sr = new StreamReader(file);
            int a = 0;

            string root1 = root();
            namaOrang = new BinaryTree<string>(root1);
            while ((line = sr.ReadLine()) != null)
            {
                    
                    string[] result = rgx.Split(line);
                    if (result[0] != root1)
                    {
                        string nama1 = result[0];
                        insertTree(nama1);
                    }
            }
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

