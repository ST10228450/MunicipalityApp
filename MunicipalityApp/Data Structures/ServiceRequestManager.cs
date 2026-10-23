using ClassLibrary;
using MunicipalityApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApp.Data_Structures
{
    /// <summary>
    /// Central service-request repository and index coordinator.
    /// This is an in-memory demonstration; data resets when the application closes.
    /// </summary>
    public class ServiceRequestManager
    {
        private readonly Dictionary<string, ServiceRequest> _requests =
            new Dictionary<string, ServiceRequest>(StringComparer.OrdinalIgnoreCase);

        private readonly ServiceRequestStructures.BinarySearchTree<string> _bst =
            new ServiceRequestStructures.BinarySearchTree<string>(StringComparer.OrdinalIgnoreCase);
        private readonly ServiceRequestStructures.AvlTree<string> _avl =
            new ServiceRequestStructures.AvlTree<string>(StringComparer.OrdinalIgnoreCase);
        private readonly ServiceRequestStructures.RedBlackTree<string> _redBlack =
            new ServiceRequestStructures.RedBlackTree<string>(StringComparer.OrdinalIgnoreCase);
        private readonly ServiceRequestStructures.BasicTree<string> _categoryTree =
            new ServiceRequestStructures.BasicTree<string>();
        private readonly ServiceRequestStructures.BinaryTree<string> _binaryTree =
            new ServiceRequestStructures.BinaryTree<string>();
        private ServiceRequestStructures.WeightedGraph _graph =
            new ServiceRequestStructures.WeightedGraph();

        private ServiceRequestStructures.MinHeap<ServiceRequest> _priorityHeap =
            new ServiceRequestStructures.MinHeap<ServiceRequest>(Comparer<ServiceRequest>.Create(ComparePriority));

        public ServiceRequestManager(bool loadSampleData = true)
        {
            if (loadSampleData) LoadSampleData();
        }

        public int Count => _requests.Count;
        public IEnumerable<ServiceRequest> GetAll() =>
            _requests.Values.OrderByDescending(r => r.SubmittedDate).ThenBy(r => r.RequestId).ToList();

        public ServiceRequest? FindById(string? requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId)) return null;
            // The dictionary gives direct O(1) average lookup; tree indexes are kept for demonstration.
            return _requests.TryGetValue(requestId.Trim(), out var request) ? request : null;
        }

        public bool ContainsInBst(string id) => _bst.Contains(id);
        public bool ContainsInAvl(string id) => _avl.Contains(id);
        public bool ContainsInRedBlackTree(string id) => _redBlack.Contains(id);

        public IEnumerable<ServiceRequest> Search(string? searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) return GetAll();
            string term = searchText.Trim();
            return GetAll().Where(r =>
                r.RequestId.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                r.Category.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                r.Location.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                r.Description.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                r.Status.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<ServiceRequest> Filter(string? status, string? priority)
        {
            var query = GetAll();
            if (!string.IsNullOrWhiteSpace(status) && status != "All statuses")
                query = query.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(priority) && priority != "All priorities")
                query = query.Where(r => r.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase));
            return query.ToList();
        }

        public bool Add(ServiceRequest request, out string message)
        {
            if (request == null) { message = "A service request is required."; return false; }
            request.RequestId = (request.RequestId ?? "").Trim();
            if (request.RequestId.Length == 0) { message = "Request ID cannot be empty."; return false; }
            if (_requests.ContainsKey(request.RequestId)) { message = "That request ID already exists."; return false; }
            if (string.IsNullOrWhiteSpace(request.Status)) request.Status = "Submitted";
            if (request.History == null) request.History = new List<string>();
            if (request.History.Count == 0)
                request.History.Add($"{DateTime.Now:g} — Request submitted. Status: {request.Status}");

            _requests.Add(request.RequestId, request);
            _bst.Insert(request.RequestId);
            _avl.Insert(request.RequestId);
            _redBlack.Insert(request.RequestId);
            RebuildIndexes();
            message = "Service request added.";
            return true;
        }

        public bool UpdateStatus(string requestId, string status, string? note, out string message)
        {
            var request = FindById(requestId);
            if (request == null) { message = "No request was found with that ID."; return false; }
            if (string.IsNullOrWhiteSpace(status)) { message = "Choose a status."; return false; }

            request.Status = status.Trim();
            string historyLine = $"{DateTime.Now:g} — Status changed to {request.Status}";
            if (!string.IsNullOrWhiteSpace(note)) historyLine += $". {note.Trim()}";
            request.History.Add(historyLine);
            RebuildIndexes();
            message = "Request status updated.";
            return true;
        }

        public IEnumerable<string> GetCategories() =>
            _requests.Values.Select(r => r.Category).Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(c => c).ToList();

        public IEnumerable<string> GetGraphBreadthFirst(string requestId) => _graph.BreadthFirst(requestId);
        public IEnumerable<string> GetGraphDepthFirst(string requestId) => _graph.DepthFirst(requestId);
        public IReadOnlyList<ServiceRequestStructures.WeightedGraph.Edge> GetMinimumSpanningForest() =>
            _graph.MinimumSpanningTree();

        public IEnumerable<ServiceRequest> GetRequestsByPriority()
        {
            var heap = new ServiceRequestStructures.MinHeap<ServiceRequest>(
                Comparer<ServiceRequest>.Create(ComparePriority));
            foreach (var request in _requests.Values) heap.Enqueue(request);
            var result = new List<ServiceRequest>();
            while (heap.Count > 0) result.Add(heap.Dequeue());
            return result;
        }

        public IEnumerable<string> GetBinarySearchTreeOrder() => _bst.InOrder();
        public IEnumerable<string> GetAvlTreeOrder() => _avl.InOrder();
        public IEnumerable<string> GetRedBlackTreeOrder() => _redBlack.InOrder();
        public IEnumerable<string> GetCategoryTreeBreadthFirst() => _categoryTree.BreadthFirst();
        public IEnumerable<string> GetBinaryTreeOrder() => _binaryTree.InOrder();

        private void RebuildIndexes()
        {
            _categoryTree.SetRoot("All Categories");
            foreach (var category in GetCategories())
                _categoryTree.AddChild("All Categories", category, StringComparer.OrdinalIgnoreCase);

            // A simple binary tree of sorted request IDs, separate from the search trees.
            var ids = _requests.Keys.OrderBy(id => id, StringComparer.OrdinalIgnoreCase).ToList();
            _binaryTree.Root = BuildBalancedBinaryTree(ids, 0, ids.Count - 1);

            _priorityHeap = new ServiceRequestStructures.MinHeap<ServiceRequest>(
                Comparer<ServiceRequest>.Create(ComparePriority));
            foreach (var request in _requests.Values) _priorityHeap.Enqueue(request);

            // Connect requests sharing a location or category. Weight 1 means both match;
            // weight 2 means only one attribute matches. The graph can be disconnected.
            var graph = new ServiceRequestStructures.WeightedGraph();
            var all = _requests.Values.ToList();
            foreach (var request in all) graph.AddVertex(request.RequestId);
            for (int i = 0; i < all.Count; i++)
            {
                for (int j = i + 1; j < all.Count; j++)
                {
                    bool sameLocation = all[i].Location.Equals(all[j].Location, StringComparison.OrdinalIgnoreCase);
                    bool sameCategory = all[i].Category.Equals(all[j].Category, StringComparison.OrdinalIgnoreCase);
                    if (sameLocation || sameCategory)
                        graph.AddEdge(all[i].RequestId, all[j].RequestId, sameLocation && sameCategory ? 1 : 2);
                }
            }
            _graph = graph;
        }

        private static ServiceRequestStructures.BinaryTreeNode<string>? BuildBalancedBinaryTree(
            IList<string> values, int start, int end)
        {
            if (start > end) return null;
            int middle = start + (end - start) / 2;
            var node = new ServiceRequestStructures.BinaryTreeNode<string>(values[middle]);
            node.Left = BuildBalancedBinaryTree(values, start, middle - 1);
            node.Right = BuildBalancedBinaryTree(values, middle + 1, end);
            return node;
        }

        private static int ComparePriority(ServiceRequest? a, ServiceRequest? b)
        {
            if (ReferenceEquals(a, b)) return 0;
            if (a == null) return 1;
            if (b == null) return -1;
            int Rank(string? priority) => priority?.Trim().ToLowerInvariant() switch
            {
                "urgent" => 0,
                "high" => 1,
                "medium" => 2,
                "low" => 3,
                _ => 4
            };
            int cmp = Rank(a.Priority).CompareTo(Rank(b.Priority));
            if (cmp != 0) return cmp;
            cmp = a.SubmittedDate.CompareTo(b.SubmittedDate);
            return cmp != 0 ? cmp : string.Compare(a.RequestId, b.RequestId, StringComparison.OrdinalIgnoreCase);
        }

        private void LoadSampleData()
        {
            var samples = new[]
            {
                new ServiceRequest { RequestId = "MS-1001", Category = "Roads", Location = "Church Street, Pretoria", Priority = "High", Status = "In Progress", Description = "Repair potholes near the intersection.", SubmittedDate = DateTime.Today.AddDays(-5) },
                new ServiceRequest { RequestId = "MS-1002", Category = "Water", Location = "Mamelodi East", Priority = "Urgent", Status = "Submitted", Description = "Report a leaking municipal water pipe.", SubmittedDate = DateTime.Today.AddDays(-2) },
                new ServiceRequest { RequestId = "MS-1003", Category = "Roads", Location = "Church Street, Pretoria", Priority = "Medium", Status = "Assigned", Description = "Inspect damaged road markings.", SubmittedDate = DateTime.Today.AddDays(-4) },
                new ServiceRequest { RequestId = "MS-1004", Category = "Electricity", Location = "Sunnyside, Pretoria", Priority = "High", Status = "In Progress", Description = "Streetlight not working.", SubmittedDate = DateTime.Today.AddDays(-3) },
                new ServiceRequest { RequestId = "MS-1005", Category = "Waste", Location = "Mamelodi East", Priority = "Low", Status = "Resolved", Description = "Missed household refuse collection.", SubmittedDate = DateTime.Today.AddDays(-8) },
                new ServiceRequest { RequestId = "MS-1006", Category = "Water", Location = "Atteridgeville", Priority = "Medium", Status = "Submitted", Description = "Low water pressure in the area.", SubmittedDate = DateTime.Today.AddDays(-1) }
            };

            foreach (var request in samples)
            {
                request.History.Add($"{request.SubmittedDate:g} — Request submitted. Status: Submitted");
                if (request.Status != "Submitted")
                    request.History.Add($"{request.SubmittedDate.AddDays(1):g} — Status changed to {request.Status}");
                _requests[request.RequestId] = request;
                _bst.Insert(request.RequestId);
                _avl.Insert(request.RequestId);
                _redBlack.Insert(request.RequestId);
            }
            RebuildIndexes();
        }
    }
}
