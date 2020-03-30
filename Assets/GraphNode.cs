using System.Collections.Generic;

class GraphNode<T>
{
    T value;
    List<GraphNode<T>> neighbours;

    public GraphNode(T value)
    {
        this.value = value;
        neighbours = new List<GraphNode<T>>();
    }

    public T Value
    {
        get { return value; }
    }

    public IList<GraphNode<T>> Neighbours
    {
        get { return neighbours.AsReadOnly(); }
    }

    public bool AddNeighbour(GraphNode<T> neighbour)
    {
        // don't add duplicate nodes
        if (neighbours.Contains(neighbour))
        {
            return false;
        }
        else
        {
            neighbours.Add(neighbour);
            return true;
        }
    }

    public bool RemoveNeighbour(GraphNode<T> neighbour)
    {
        // only remove neighbours in list
        return neighbours.Remove(neighbour);
    }

    public bool RemoveAllNeighbours()
    {
        for (int i = neighbours.Count - 1; i >= 0; i--)
        {
            neighbours.RemoveAt(i);
        }
        return true;
    }
}