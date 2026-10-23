# Municipal Services Application — Service Request Status implementation

## Files included

- `Data Structures/ServiceRequestManager.cs` — coordinates request records, search indexes, sample data, priority ordering and graph analysis.
- `Services/ServiceRequestStructures.cs` — basic n-ary tree, binary tree node/traversal, binary search tree, AVL tree, red-black tree, min-heap, weighted graph, BFS, DFS and Kruskal minimum spanning forest.
- `ViewServiceRequestsWindow.cs` — form event handlers, tracking, filters, progress history and analysis actions.
- `ViewServiceRequestsWindow.Designer.cs` — Windows Forms UI using an orange/brown palette.

## Add to the existing Visual Studio solution

1. Keep your existing `ClassLibrary.ServiceRequest` model. It must contain `RequestId`, `Category`, `Location`, `Priority`, `Status`, `Description`, `SubmittedDate`, and `List<string> History`.
2. Replace the empty `ServiceRequestManager.cs` and `ServiceRequestStructures.cs` files with the supplied files. Ensure the namespaces match the folders/project names.
3. Replace the contents of `ViewServiceRequestsWindow.cs` and `ViewServiceRequestsWindow.Designer.cs` with the supplied versions. Keep the files nested/paired as they are in your screenshot.
4. Ensure the `MunicipalityApp` Windows Forms project references the `ClassLibrary` project.
5. Build the solution. The UI uses `TextBox.PlaceholderText`, available in modern Windows Forms (.NET 6+). If your project targets .NET Framework, remove those `PlaceholderText` assignments.

## Open the form from MainMenu

Add `using MunicipalityApp.Data_Structures;` only if you want to share a manager instance. The simplest menu click handler is:

```csharp
private void btnServiceRequestStatus_Click(object sender, EventArgs e)
{
    using var window = new ViewServiceRequestsWindow();
    window.ShowDialog(this);
}
```

Connect the handler to the existing “Service Request Status” button. If your button has a different name, use its name in the event handler. The default constructor loads sample requests so the screen is immediately demonstrable.

## Demonstrating the data structures

- Basic tree: groups category names below an `All Categories` root.
- Binary tree: a balanced binary tree built from sorted request IDs.
- Binary search tree: indexes request IDs and returns them in sorted in-order traversal.
- AVL tree: self-balancing request-ID index.
- Red-black tree: self-balancing request-ID index.
- Min-heap: orders requests by Urgent, High, Medium, Low, then submission date.
- Graph: connects requests sharing a category or location; weight 1 means both attributes match, weight 2 means one matches.
- BFS and DFS: traverse the related-request graph from a chosen request ID.
- Kruskal MST: returns a minimum spanning forest, because the related-request graph may be disconnected.

## Important limitations / production considerations

This implementation intentionally stores requests in memory and includes six sample records. Records and status changes are lost when the application closes. For a production application, persist the requests and history in SQL Server using Entity Framework Core, validate status transitions, and restrict status updates to authorised municipal staff. The graph is rebuilt after changes, which is suitable for an assignment demonstration but could be optimised for large datasets.
