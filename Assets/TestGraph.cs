using UnityEngine;

public class TestGraph : MonoBehaviour
{
    void PrintNeighbours(GraphNode<int> _node) 
    {
        if(_node.Neighbours.Count == 0) Debug.Log("No Neighbours");
        foreach (GraphNode<int> node in _node.Neighbours) {
            Debug.Log("Neighbour Value: " + node.Value);
        }
    }

    void TestAddEdgeValid()
    {
        Graph<int> graph = new Graph<int>();
        graph.AddNode(4);
        graph.AddNode(5);
        graph.AddNode(6);
        bool[] success = new bool[3];
        success[0] = graph.AddEdge(4, 5);
        success[1] = graph.AddEdge(5, 6);
        success[2] = graph.AddEdge(4, 6);

        Debug.Log("TestAddEdgeValid: ");
        foreach (GraphNode<int> node in graph.Nodes) {
            Debug.Log("Node Value: " + node.Value + ", Neighbour List: ");
            PrintNeighbours(node);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        TestAddEdgeValid();
    }
}
