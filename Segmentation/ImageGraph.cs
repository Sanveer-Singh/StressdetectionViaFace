using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StressdetectionViaFace.Facedetection; 

namespace StressdetectionViaFace.Segmentation
{
    class ImageGraph
    {
        // THE IMAGE COLLECTION 
        RGBImage myrgb;
        Bitmap Greyscaled;
        Bitmap myGradientImage;
        Bitmap OriginalImage;

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

        //public List<List<ImageNode>> GetBlobs()
        //{
        //     FaceClassifier classifier = new  FaceClassifier(OriginalImage);
        //    myrgb = classifier.GetDetectedWithMask();
        //    Greyscaled = Preprocessing.GreyScalar.GreyscaleThis(OriginalImage);
        //    GradientImage Gi = new GradientImage();
 
            
        //    myGradientImage = Gi.GetTotalEdgeImage(Greyscaled);
        //    ImageNode current = getNodeAt(0, 0);
        //    double direction = 0;// true is right
        //    ImageEdge edgeToNext;
        //    ImageNode next;
        //    bool hasnext = true;
        //    bool nextNotFound = true; 

        //    while(hasnext && nextNotFound )
        //    {
        //        switch (direction)
        //        {
        //            case 0:
        //                {
        //                    edgeToNext = current.RightEdge;
        //                    if (edgeToNext is null)
        //                    {
        //                        direction = 1;
        //                    }
        //                    else
        //                    {
        //                        next = edgeToNext.Destination();
        //                        nextNotFound = false;
        //                    }

        //                }
        //                break;

        //            case 1:
        //                {
        //                    edgeToNext = current.leftEdge;
        //                    if (edgeToNext is null)
        //                    {
        //                        direction = 2;
        //                    }
        //                    else
        //                    {
        //                        next = edgeToNext.Destination();
        //                        nextNotFound = false;
        //                    }
        //                }
        //                break;
        //            case 2:
        //                {
        //                    edgeToNext = current.DownEdge;
        //                    if (edgeToNext is null)
        //                    {
        //                        direction = 2;
        //                        hasnext = false;
        //                    }
        //                    else
        //                    {
        //                        next = edgeToNext.Destination();
        //                        nextNotFound = false;
        //                    }

        //                }
        //                break;
        //            default:
        //                {

        //                }
        //                break;
        //        }
        //    }
        //    // next is either null or exists 
        //    if(hasnext)
        //    {
        //        // next is viable 



        //    }
            


        //}

        public void traverse()
        {

        }

                // get biggest blob 

                // get isskinatx&y

                // get Gradient at x,y

            }
}
