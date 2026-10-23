using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApp.Services
{
    /// <summary>
    /// Reusable implementations of the data structures required by the PoE.
    /// The manager composes these structures to index and analyse service requests.
    /// </summary>
    public class ServiceRequestStructures
    {
        // -------------------- Basic (N-ary) tree --------------------
        public sealed class TreeNode<T>
        {
            public T Value { get; }
            public List<TreeNode<T>> Children { get; } = new List<TreeNode<T>>();
            public TreeNode(T value) => Value = value;
        }

        public sealed class BasicTree<T>
        {
            public TreeNode<T>? Root { get; private set; }
            public TreeNode<T> SetRoot(T value) => Root = new TreeNode<T>(value);

            public TreeNode<T>? Find(T value, IEqualityComparer<T>? comparer = null)
            {
                if (Root == null) return null;
                comparer ??= EqualityComparer<T>.Default;
                var queue = new Queue<TreeNode<T>>();
                queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (comparer.Equals(current.Value, value)) return current;
                    foreach (var child in current.Children) queue.Enqueue(child);
                }
                return null;
            }

            public TreeNode<T>? AddChild(T parentValue, T childValue, IEqualityComparer<T>? comparer = null)
            {
                var parent = Find(parentValue, comparer);
                if (parent == null) return null;
                var child = new TreeNode<T>(childValue);
                parent.Children.Add(child);
                return child;
            }

            public IEnumerable<T> BreadthFirst()
            {
                if (Root == null) yield break;
                var queue = new Queue<TreeNode<T>>();
                queue.Enqueue(Root);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    yield return current.Value;
                    foreach (var child in current.Children) queue.Enqueue(child);
                }
            }
        }

        // -------------------- Binary tree --------------------
        public sealed class BinaryTreeNode<T>
        {
            public T Value { get; set; }
            public BinaryTreeNode<T>? Left { get; set; }
            public BinaryTreeNode<T>? Right { get; set; }
            public BinaryTreeNode(T value) => Value = value;
        }

        public sealed class BinaryTree<T>
        {
            public BinaryTreeNode<T>? Root { get; set; }

            public IEnumerable<T> InOrder()
            {
                var stack = new Stack<BinaryTreeNode<T>>();
                var current = Root;
                while (current != null || stack.Count > 0)
                {
                    while (current != null) { stack.Push(current); current = current.Left; }
                    current = stack.Pop();
                    yield return current.Value;
                    current = current.Right;
                }
            }
        }

        // -------------------- Binary search tree --------------------
        public sealed class BinarySearchTree<T>
        {
            public sealed class Node
            {
                public T Value;
                public Node? Left, Right;
                public Node(T value) => Value = value;
            }

            private readonly IComparer<T> _comparer;
            public Node? Root { get; private set; }
            public BinarySearchTree(IComparer<T>? comparer = null) => _comparer = comparer ?? Comparer<T>.Default;

            public void Insert(T value) => Root = Insert(Root, value);
            private Node Insert(Node? node, T value)
            {
                if (node == null) return new Node(value);
                int cmp = _comparer.Compare(value, node.Value);
                if (cmp < 0) node.Left = Insert(node.Left, value);
                else if (cmp > 0) node.Right = Insert(node.Right, value);
                return node;
            }

            public bool Contains(T value)
            {
                var node = Root;
                while (node != null)
                {
                    int cmp = _comparer.Compare(value, node.Value);
                    if (cmp == 0) return true;
                    node = cmp < 0 ? node.Left : node.Right;
                }
                return false;
            }

            public IEnumerable<T> InOrder()
            {
                var stack = new Stack<Node>();
                var node = Root;
                while (node != null || stack.Count > 0)
                {
                    while (node != null) { stack.Push(node); node = node.Left; }
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }

        // -------------------- AVL tree --------------------
        public sealed class AvlTree<T>
        {
            public sealed class Node
            {
                public T Value;
                public int Height = 1;
                public Node? Left, Right;
                public Node(T value) => Value = value;
            }

            private readonly IComparer<T> _comparer;
            public Node? Root { get; private set; }
            public AvlTree(IComparer<T>? comparer = null) => _comparer = comparer ?? Comparer<T>.Default;
            private static int Height(Node? n) => n?.Height ?? 0;
            private static void Update(Node n) => n.Height = 1 + Math.Max(Height(n.Left), Height(n.Right));
            private static int Balance(Node n) => Height(n.Left) - Height(n.Right);

            private static Node RotateRight(Node y)
            {
                var x = y.Left!;
                var t2 = x.Right;
                x.Right = y; y.Left = t2;
                Update(y); Update(x);
                return x;
            }

            private static Node RotateLeft(Node x)
            {
                var y = x.Right!;
                var t2 = y.Left;
                y.Left = x; x.Right = t2;
                Update(x); Update(y);
                return y;
            }

            public void Insert(T value) => Root = Insert(Root, value);
            private Node Insert(Node? node, T value)
            {
                if (node == null) return new Node(value);
                int cmp = _comparer.Compare(value, node.Value);
                if (cmp < 0) node.Left = Insert(node.Left, value);
                else if (cmp > 0) node.Right = Insert(node.Right, value);
                else return node;

                Update(node);
                int balance = Balance(node);
                if (balance > 1 && _comparer.Compare(value, node.Left!.Value) < 0) return RotateRight(node);
                if (balance < -1 && _comparer.Compare(value, node.Right!.Value) > 0) return RotateLeft(node);
                if (balance > 1 && _comparer.Compare(value, node.Left!.Value) > 0)
                {
                    node.Left = RotateLeft(node.Left!);
                    return RotateRight(node);
                }
                if (balance < -1 && _comparer.Compare(value, node.Right!.Value) < 0)
                {
                    node.Right = RotateRight(node.Right!);
                    return RotateLeft(node);
                }
                return node;
            }

            public bool Contains(T value)
            {
                var node = Root;
                while (node != null)
                {
                    int cmp = _comparer.Compare(value, node.Value);
                    if (cmp == 0) return true;
                    node = cmp < 0 ? node.Left : node.Right;
                }
                return false;
            }

            public IEnumerable<T> InOrder()
            {
                var stack = new Stack<Node>();
                var node = Root;
                while (node != null || stack.Count > 0)
                {
                    while (node != null) { stack.Push(node); node = node.Left; }
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }

        // -------------------- Red-black tree --------------------
        public sealed class RedBlackTree<T>
        {
            private enum Colour { Red, Black }
            private sealed class Node
            {
                public T Value;
                public Colour Colour;
                public Node? Left, Right, Parent;
                public Node(T value, Colour colour) { Value = value; Colour = colour; }
            }

            private readonly IComparer<T> _comparer;
            private Node? _root;
            public RedBlackTree(IComparer<T>? comparer = null) => _comparer = comparer ?? Comparer<T>.Default;

            public void Insert(T value)
            {
                var z = new Node(value, Colour.Red);
                Node? parent = null;
                var current = _root;
                while (current != null)
                {
                    parent = current;
                    int cmp = _comparer.Compare(z.Value, current.Value);
                    if (cmp == 0) return;
                    current = cmp < 0 ? current.Left : current.Right;
                }
                z.Parent = parent;
                if (parent == null) _root = z;
                else if (_comparer.Compare(z.Value, parent.Value) < 0) parent.Left = z;
                else parent.Right = z;
                FixInsert(z);
            }

            public bool Contains(T value)
            {
                var n = _root;
                while (n != null)
                {
                    int cmp = _comparer.Compare(value, n.Value);
                    if (cmp == 0) return true;
                    n = cmp < 0 ? n.Left : n.Right;
                }
                return false;
            }

            public IEnumerable<T> InOrder()
            {
                var stack = new Stack<Node>();
                var n = _root;
                while (n != null || stack.Count > 0)
                {
                    while (n != null) { stack.Push(n); n = n.Left; }
                    n = stack.Pop(); yield return n.Value; n = n.Right;
                }
            }

            private static Colour ColourOf(Node? n) => n?.Colour ?? Colour.Black;
            private void RotateLeft(Node x)
            {
                var y = x.Right!;
                x.Right = y.Left;
                if (y.Left != null) y.Left.Parent = x;
                y.Parent = x.Parent;
                if (x.Parent == null) _root = y;
                else if (x == x.Parent.Left) x.Parent.Left = y;
                else x.Parent.Right = y;
                y.Left = x; x.Parent = y;
            }
            private void RotateRight(Node y)
            {
                var x = y.Left!;
                y.Left = x.Right;
                if (x.Right != null) x.Right.Parent = y;
                x.Parent = y.Parent;
                if (y.Parent == null) _root = x;
                else if (y == y.Parent.Right) y.Parent.Right = x;
                else y.Parent.Left = x;
                x.Right = y; y.Parent = x;
            }
            private void FixInsert(Node z)
            {
                while (z.Parent != null && ColourOf(z.Parent) == Colour.Red)
                {
                    var parent = z.Parent;
                    var grand = parent.Parent!;
                    if (parent == grand.Left)
                    {
                        var uncle = grand.Right;
                        if (ColourOf(uncle) == Colour.Red)
                        {
                            parent.Colour = Colour.Black; uncle!.Colour = Colour.Black;
                            grand.Colour = Colour.Red; z = grand;
                        }
                        else
                        {
                            if (z == parent.Right) { z = parent; RotateLeft(z); parent = z.Parent!; grand = parent.Parent!; }
                            parent.Colour = Colour.Black; grand.Colour = Colour.Red; RotateRight(grand);
                        }
                    }
                    else
                    {
                        var uncle = grand.Left;
                        if (ColourOf(uncle) == Colour.Red)
                        {
                            parent.Colour = Colour.Black; uncle!.Colour = Colour.Black;
                            grand.Colour = Colour.Red; z = grand;
                        }
                        else
                        {
                            if (z == parent.Left) { z = parent; RotateRight(z); parent = z.Parent!; grand = parent.Parent!; }
                            parent.Colour = Colour.Black; grand.Colour = Colour.Red; RotateLeft(grand);
                        }
                    }
                }
                if (_root != null) _root.Colour = Colour.Black;
            }
        }

        // -------------------- Binary min-heap --------------------
        public sealed class MinHeap<T>
        {
            private readonly List<T> _items = new List<T>();
            private readonly IComparer<T> _comparer;
            public int Count => _items.Count;
            public MinHeap(IComparer<T>? comparer = null) => _comparer = comparer ?? Comparer<T>.Default;

            public void Enqueue(T item)
            {
                _items.Add(item);
                int i = _items.Count - 1;
                while (i > 0)
                {
                    int p = (i - 1) / 2;
                    if (_comparer.Compare(_items[p], _items[i]) <= 0) break;
                    (_items[p], _items[i]) = (_items[i], _items[p]);
                    i = p;
                }
            }

            public T Dequeue()
            {
                if (_items.Count == 0) throw new InvalidOperationException("The heap is empty.");
                T result = _items[0];
                T last = _items[_items.Count - 1];
                _items.RemoveAt(_items.Count - 1);
                if (_items.Count > 0)
                {
                    _items[0] = last;
                    int i = 0;
                    while (true)
                    {
                        int left = i * 2 + 1, right = left + 1, smallest = i;
                        if (left < _items.Count && _comparer.Compare(_items[left], _items[smallest]) < 0) smallest = left;
                        if (right < _items.Count && _comparer.Compare(_items[right], _items[smallest]) < 0) smallest = right;
                        if (smallest == i) break;
                        (_items[i], _items[smallest]) = (_items[smallest], _items[i]);
                        i = smallest;
                    }
                }
                return result;
            }

            public T Peek() => _items.Count == 0 ? throw new InvalidOperationException("The heap is empty.") : _items[0];
            public IEnumerable<T> UnorderedItems => _items.ToList();
        }

        // -------------------- Weighted undirected graph --------------------
        public sealed class WeightedGraph
        {
            public sealed class Edge
            {
                public string From { get; }
                public string To { get; }
                public int Weight { get; }
                public Edge(string from, string to, int weight) { From = from; To = to; Weight = weight; }
                public override string ToString() => $"{From} -- {To} (weight {Weight})";
            }

            private readonly Dictionary<string, List<(string To, int Weight)>> _adjacency =
                new Dictionary<string, List<(string To, int Weight)>>(StringComparer.OrdinalIgnoreCase);

            public IEnumerable<string> Vertices => _adjacency.Keys;
            public void AddVertex(string id)
            {
                if (!string.IsNullOrWhiteSpace(id) && !_adjacency.ContainsKey(id))
                    _adjacency[id] = new List<(string To, int Weight)>();
            }

            public void AddEdge(string from, string to, int weight)
            {
                if (from == to || weight < 0) return;
                AddVertex(from); AddVertex(to);
                if (!_adjacency[from].Any(e => e.To.Equals(to, StringComparison.OrdinalIgnoreCase)))
                    _adjacency[from].Add((to, weight));
                if (!_adjacency[to].Any(e => e.To.Equals(from, StringComparison.OrdinalIgnoreCase)))
                    _adjacency[to].Add((from, weight));
            }

            public IEnumerable<string> BreadthFirst(string start)
            {
                if (!_adjacency.ContainsKey(start)) return Enumerable.Empty<string>();
                var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var result = new List<string>();
                var queue = new Queue<string>(); queue.Enqueue(start); visited.Add(start);
                while (queue.Count > 0)
                {
                    var v = queue.Dequeue(); result.Add(v);
                    foreach (var edge in _adjacency[v])
                        if (visited.Add(edge.To)) queue.Enqueue(edge.To);
                }
                return result;
            }

            public IEnumerable<string> DepthFirst(string start)
            {
                if (!_adjacency.ContainsKey(start)) return Enumerable.Empty<string>();
                var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                var result = new List<string>();
                var stack = new Stack<string>(); stack.Push(start);
                while (stack.Count > 0)
                {
                    var v = stack.Pop();
                    if (!visited.Add(v)) continue;
                    result.Add(v);
                    foreach (var edge in _adjacency[v].OrderByDescending(e => e.To, StringComparer.OrdinalIgnoreCase))
                        if (!visited.Contains(edge.To)) stack.Push(edge.To);
                }
                return result;
            }

            /// <summary>Kruskal minimum spanning forest. A forest is returned when the graph is disconnected.</summary>
            public List<Edge> MinimumSpanningTree()
            {
                var edges = new List<Edge>();
                foreach (var pair in _adjacency)
                    foreach (var e in pair.Value)
                        if (string.Compare(pair.Key, e.To, StringComparison.OrdinalIgnoreCase) < 0)
                            edges.Add(new Edge(pair.Key, e.To, e.Weight));

                var parent = _adjacency.Keys.ToDictionary(k => k, k => k, StringComparer.OrdinalIgnoreCase);
                var rank = _adjacency.Keys.ToDictionary(k => k, _ => 0, StringComparer.OrdinalIgnoreCase);
                string Find(string x)
                {
                    if (!parent[x].Equals(x, StringComparison.OrdinalIgnoreCase))
                        parent[x] = Find(parent[x]);
                    return parent[x];
                }
                void Union(string a, string b)
                {
                    var ra = Find(a); var rb = Find(b);
                    if (ra.Equals(rb, StringComparison.OrdinalIgnoreCase)) return;
                    if (rank[ra] < rank[rb]) parent[ra] = rb;
                    else if (rank[ra] > rank[rb]) parent[rb] = ra;
                    else { parent[rb] = ra; rank[ra]++; }
                }

                var result = new List<Edge>();
                foreach (var edge in edges.OrderBy(e => e.Weight).ThenBy(e => e.From).ThenBy(e => e.To))
                {
                    if (Find(edge.From).Equals(Find(edge.To), StringComparison.OrdinalIgnoreCase)) continue;
                    Union(edge.From, edge.To);
                    result.Add(edge);
                }
                return result;
            }
        }
    }
}
