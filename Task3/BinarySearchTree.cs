using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Класс "Бинарное поисковое дерево"
    /// </summary>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// ссылка на корень дерева
        /// </summary>
        private TreeNode root;

        private IComparer<T> comparer;

        /// <summary>
        /// конструктор дерева
        /// </summary>
        public BinarySearchTree(IComparer<T> comparer)
        {
            TreeInitialize(comparer);
        }

        public BinarySearchTree(Comparison<T> comparison)
        {
            TreeInitialize(Comparer<T>.Create(comparison));
        }

        /// <summary>
        /// конструктор дерева
        /// </summary>
        public BinarySearchTree()
        {
            TreeInitialize(null);
        }

        private void TreeInitialize(IComparer<T> comparer)
        {
            if (comparer == null)
            {
                if (typeof(T).GetInterface("IComparable`1") != null || typeof(T).GetInterface("IComparable") != null)
                {
                    comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException("Comparer must be specified for types without IComparable");
                }
            }

            root = null;
        }

        /// <summary>
        /// внутренняя процедура поиска
        /// </summary>
        /// <param name="x">искомое значение</param>
        /// <param name="p">ели найдено - ссылка на соответствующий узел, иначе - ссылка на то место, где остановились</param>
        /// <returns>нашли или нет</returns>
        private bool Find(T x, out TreeNode p)
        {
            p = root;
            TreeNode q = p;
            while (q != null)
            {
                p = q;
                int comparison = comparer.Compare(q.value, x);
                if (comparison == 0)
                {
                    return true;
                }
                else if (comparison < 0)
                {
                    q = q.rSon;
                }
                else
                {
                    q = q.lSon;
                }
            }
            return false;
        }

        /// <summary>
        /// внешняя процедура поиска
        /// </summary>
        /// <param name="x">искомое значение</param>
        /// <returns>нашли или нет</returns>
        public bool Find(T x)
        {
            TreeNode p;
            return Find(x, out p);
        }

        /// <summary>
        /// втавка в БПД
        /// </summary>
        /// <param name="x">вставляемое значение</param>
        /// <returns>смогли вставить или нет</returns>
        public bool Insert(T x)
        {
            TreeNode r, p;
            if (root == null)
            {
                root = new TreeNode(x);
                return true;
            }

            if (Find(x, out r))
            {
                return false;
            }

            p = new TreeNode(x);
            p.father = r;
            if (comparer.Compare(r.value, x) < 0)
            {
                r.rSon = p;
            }
            else
            {
                r.lSon = p;
            }

            return true;
        }

        /// <summary>
        /// удалить вершину (оборвать все ссылки)
        /// </summary>
        /// <param name="x">удаляемая вершина</param>
        private void deleteNode(TreeNode x)
        {
            if (x.father == null)
                if (x.lSon != null)
                {
                    root = x.lSon;
                    x.lSon.father = null;
                }
                else
                {
                    root = x.rSon;
                    if (x.rSon != null)
                        x.rSon.father = null;
                }
            else
                if (x.father.lSon == x)
                if (x.lSon != null)
                {
                    x.father.lSon = x.lSon;
                    x.lSon.father = x.father;
                }
                else
                {
                    x.father.lSon = x.rSon;
                    if (x.rSon != null)
                        x.rSon.father = x.father;
                }
            else
                    if (x.lSon != null)
            {
                x.father.rSon = x.lSon;
                x.lSon.father = x.father;
            }
            else
            {
                x.father.rSon = x.rSon;
                if (x.rSon != null)
                    x.rSon.father = x.father;
            }
            x.father = x.lSon = x.rSon = null;
        }

        /// <summary>
        /// Удалить вершину по значению
        /// </summary>
        /// <param name="x">удаляемое значение</param>
        /// <returns>смогли удалить или нет</returns>
        public bool Delete(T x)
        {
            TreeNode r, p;
            if (!Find(x, out r))
                return false;
            if ((r.lSon == null) || (r.rSon == null))
            {
                deleteNode(r);
                return true;
            }
            p = r.lSon;
            while (p.rSon != null)
                p = p.rSon;
            r.value = p.value;
            deleteNode(p);
            return true;
        }

        /// <summary>
        /// Класс "узел БПД"
        /// </summary>
        private class TreeNode
        {
            /// <summary>
            /// info - значение, хранящееся в узле
            /// lSon, rSon, father - ссылки на левого, правого сына и отца
            /// </summary>
            public T value;
            public TreeNode lSon, rSon, father;
            /// <summary>
            /// Конструктор узла БПД
            /// </summary>
            /// <param name="x">значение, хранящееся в узле</param>
            public TreeNode(T x)
            {
                value = x;
                lSon = rSon = father = null;
            }
        }
    }
}