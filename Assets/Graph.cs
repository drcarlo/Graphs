using System.Collections.Generic;
class Graph<T>
{
    List<GraphNode<T>> nodes = new List<GraphNode<T>>();

    public int Count
    {
        get { return nodes.Count; }
    }

    public IList<GraphNode<T>> Nodes
    {
        get { return nodes.AsReadOnly(); }
    }

    public void Clear()
    {
        // remove all the neighbours from each node
        // so nodes can be garbage collected
        foreach (GraphNode<T> node in nodes)
        {
            node.RemoveAllNeighbours();
        }

        // now remove all the nodes from the graph
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            nodes.RemoveAt(i);
        }
    }

    public bool AddNode(T value)
    {
        if (Find(value) != null)
        {
            // duplicate value
            return false;
        }
        else
        {
            nodes.Add(new GraphNode<T>(value));
            return true;
        }
    }

    public bool AddEdge(T value1, T value2)
    {
        GraphNode<T> node1 = Find(value1);
        GraphNode<T> node2 = Find(value2);
        if (node1 == null ||
            node2 == null)
        {
            return false;
        }
        else if (node1.Neighbours.Contains(node2))
        {
            // edge already exists
            return false;
        }
        else
        {
            // directed graph, so add edge from node1 to node2
            node1.AddNeighbour(node2);
            return true;
        }
    }

    public bool RemoveNode(T value)
    {
        GraphNode<T> removeNode = Find(value);
        if (removeNode == null)
        {
            return false;
        }
        else
        {
            // need to remove as neighour for all nodes
            // in graph
            nodes.Remove(removeNode);
            foreach (GraphNode<T> node in nodes)
            {
                node.RemoveNeighbour(removeNode);
            }
            return true;
        }
    }

    public bool RemoveEdge(T value1, T value2)
    {
        GraphNode<T> node1 = Find(value1);
        GraphNode<T> node2 = Find(value2);
        if (node1 == null ||
            node2 == null)
        {
            return false;
        }
        else if (!node1.Neighbours.Contains(node2))
        {
            // edge doesn't exist
            return false;
        }
        else
        {
            // directed graph, so remove node2 as neighbour of node 1
            node1.RemoveNeighbour(node2);
            return true;
        }
    }

    public GraphNode<T> Find(T value)
    {
        foreach (GraphNode<T> node in nodes)
        {
            if (node.Value.Equals(value))
            {
                return node;
            }
        }
        return null;
    }
}