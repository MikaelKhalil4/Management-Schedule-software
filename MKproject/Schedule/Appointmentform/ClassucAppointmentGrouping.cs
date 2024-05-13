using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MKproject.Schedule
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;
    using System.Windows.Documents;
    using System.Windows.Forms;



    //Target of this class: create serpents which means connected component is a set of nodes where each node is reachable by row from any other node within the same set, dorectly on undirectly.
    public class ClassucAppointmentGrouping
    {
        private TableLayoutPanel TLP;
        private List<UCappointment> controls;
        private Dictionary<UCappointment, List<int>> controlRows;
        private Dictionary<UCappointment, List<UCappointment>> adjacencyList;

        //kermel el serpents second mode
        private List<int> targetColumns;
        public ClassucAppointmentGrouping(TableLayoutPanel TLP, List<UCappointment> desiredUC, List<int> targetColumns)
        {
            this.TLP = TLP;
            this.targetColumns = targetColumns;
            this.controls = desiredUC;
            controlRows = new Dictionary<UCappointment, List<int>>();
            adjacencyList = new Dictionary<UCappointment, List<UCappointment>>();
            Initialize();
        }
     
        private void Initialize()
        {
            if (controls != null)
            {
                // Map each UCappointment to its row range
                foreach (var uc in controls)
                {
                    CreatingAdjacencyList(uc);
                }
            }
            else if(targetColumns!=null)
            {
                List<UCappointment> ListUC = new List<UCappointment>();
           
                for (int i = 0; i < TLP.RowCount; i++)
                {
                    for (int j = targetColumns[0]; j <= targetColumns[targetColumns.Count()-1]; j++)
                    {
                        UCappointment founducapp = (UCappointment)TLP.GetControlFromPosition(j, i);
                        if (founducapp != null)
                        {
                            if (!ListUC.Contains(founducapp))
                            {
                                ListUC.Add(founducapp);
                                CreatingAdjacencyList(founducapp);

                            }

                        }
                    }
                }
             
            }

            // Build the adjacency list based on row intersections
            foreach (var uc in controlRows.Keys)
            {
                foreach (var other in controlRows.Keys)
                {
                    if (uc != other && controlRows[uc].Intersect(controlRows[other]).Any())
                    {
                        adjacencyList[uc].Add(other);
                    }
                }
            }
        }
        void CreatingAdjacencyList(UCappointment uc)
        {
            int startRow = TLP.GetRow(uc);
            int rowSpan = TLP.GetRowSpan(uc);
            var rows = Enumerable.Range(startRow, rowSpan).ToList();
            controlRows[uc] = rows;

            // Ensure each UCappointment is in the adjacency list even if it has no neighbors
            adjacencyList[uc] = new List<UCappointment>();
        }

        public Dictionary<int, List<UCappointment>> ClassifyGroupsThatAreConnected()//this method is use when targeted column = null, li btaamlo enno btaatina groups of connected uccs li batenun bel desiredUC
        {
            Dictionary<int, List<UCappointment>> groups = new Dictionary<int, List<UCappointment>>();
            HashSet<UCappointment> visited = new HashSet<UCappointment>();
            int groupId = 0;

            // Helper function for depth-first search to identify connected components
            void DFS(UCappointment start)
            {
                Stack<UCappointment> stack = new Stack<UCappointment>();
                stack.Push(start);
                visited.Add(start);
                groups[groupId].Add(start);

                while (stack.Count > 0)
                {
                    UCappointment current = stack.Pop();
                    foreach (UCappointment neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            stack.Push(neighbor);
                            groups[groupId].Add(neighbor);
                        }
                    }
                }
            }

            // Initialize DFS for all unvisited appointments
            foreach (var uc in controls)
            {
                if (!visited.Contains(uc))
                {
                    groups.Add(groupId, new List<UCappointment>());
                    DFS(uc);
                    groupId++;
                }
            }

            // Sorting each group in the dictionary
            foreach (var group in groups.Keys.ToList())
            {
                groups[group].Sort((x, y) =>
                    x.ColumnIndex != y.ColumnIndex ? x.ColumnIndex.CompareTo(y.ColumnIndex) : x.RowIndexStart.CompareTo(y.RowIndexStart));
            }
            return groups; //ejbare to be sorted Column Asc, Row Asc
        }



        //
        public List<UCappointment> GetConnectedComponent(UCappointment targetUC)//this method is used when targeted column != null, what she do awwal shi, bet shelle kell serpent bel columns li eltella aanun, then it filter me the serpen include targetUC, that why bet redd one list
        {
            if (!adjacencyList.ContainsKey(targetUC))
            {
                return new List<UCappointment>(); // Return empty list if targetUC is not in specified columns or has no intersections
            }

            List<UCappointment> component = new List<UCappointment>();
            HashSet<UCappointment> visited = new HashSet<UCappointment>();
            DFS(targetUC, visited, component);

            // Sort the component based on RowIndex and ColumnIndex
            component.Sort((x, y) => x.ColumnIndex != y.ColumnIndex ? x.ColumnIndex.CompareTo(y.ColumnIndex) : x.RowIndexStart.CompareTo(y.RowIndexStart));//ejbare to be sorted Column Asc, Row Asc

            return component;
        }

        private void DFS(UCappointment uc, HashSet<UCappointment> visited, List<UCappointment> component)
        {
            Stack<UCappointment> stack = new Stack<UCappointment>();
            stack.Push(uc);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    component.Add(current);
                    foreach (var neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }
    }

}
