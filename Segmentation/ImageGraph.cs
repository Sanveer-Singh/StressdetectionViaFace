using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressdetectionViaFace.Segmentation
{
    class ImageGraph
    {
        // has list of nodes 
        List<ImageNode> Nodes;
        // has list of edges
        List<ImageEdge> Edges;


        // knows image bounds
        double width;
        double height;
        double threshold;

        // has source and basin nodes
        ImageNode Source = new ImageNode(-1,-1);
        ImageNode Basin = new ImageNode(-2,-2);
        
        // Construct graph
        
        // assign weights to edges
        private void AssignWeights(ImageEdge edge)
        {
            if (edge.FromHere()  == Source)
            {
                // this is from the source 
                // use if skin node 
            }
            else
            {
                if (edge.FromHere() == Basin)
                {
                    // from basin 
                    // use oposite of source
                }else
                {
                    // normal node
                    // get the gradient
                }

            }
            

        }

        // get node at pixel co-ordinate

        public ImageNode  getNodeAt(int x,int y)
        {
            ImageNode found = null;
            foreach (ImageNode node in Nodes )
            {
                if ((node.Xvalue == x) && (node.YValue == y))
                {
                    found = node;
                }
            }
            return found;
        }

        // check if there is an edge between two pixels

        public ImageEdge FindEdge(ImageNode from , ImageNode to)
        {
            ImageEdge found = null;
            foreach (ImageEdge  edge in Edges )
            {
                if ((edge.FromHere()  == from) && (edge.Destination() == to ))
                {
                    found = edge;
                }
            }
            return found;
        }

        // perform min cut 
        public void MinCut()
        {
            for(int x = 0; x< Edges.Count; x++)
            {
                if (Edges[x].Weight <threshold )
                {
                    Edges[x] = null;
                }
            }
       

        }

        // get blobs via bfs

        public List<List<ImageNode>> GetBlobs()
        {
           
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                   
                }
            }


        }

                // get biggest blob 

                // get isskinatx&y

                // get Gradient at x,y

            }
}
