                         DESIGN AND ANALYSIS OF ALGORITHM (CSE – 5311)
  Project Report on Sorting Algorithms
   Bhattaram Sai Santhosh -1001874167

Search Algorithms Implemented:
•	Linear Search 
•	Binary Search
•	Binary Search Tree
•	Red Black Tree
Time Complexities :
•	Linear Search – Best Case: Ω(1),  Average: Θ (N), Worst case: O(N)
•	Binary Search (sorted array) -  Best Case: Ω(1), Average:  Θ (log N), Worst Case: O(log N)
•	Binary Search Tree-  Best Case: Ω(1), Worst Case : O(N), Average Case: Θ (log N)
•	Red black Tree – Best Case: Ω(1),  Worst Case: O(log N), Average Case : Θ (log N)
GUI Web Page (Default.aspx):
The web page for getting the input size from the user, algorithm selection, and charts are written on this page.
 

 


GUI  Web Page Code Behind cs file(Default.aspx.cs):
This is code behind the component for the Default aspx page it has actions to be performed by the button click event. 
 


 

 


 

 



 

Binary Search Tree class (BinarySearchTree.cs):
This class has the code for performing Binary Searching Tree algorithm like Insertion and searching.
 


 

Node class(Node.cs) : This has the structure of the Binary search tree node.
 

Searching Algorithms (SearchingAlgorithm.cs):
This has the implementations of Linear search algorithm and binary search algorithm.
 
RedBlack Tree (RedBlackNode.cs):
This has the implementation of Redblack tree like insertion, and searching. 

 

 

 


 


 


 


Site.Master: This is the master page of the application.
 
Results:
•	Results generated when a randomly generating input array with input size 10 and searching a random key and comparing the running times for the algorithms are given below.

 

•	Results generated  by randomly generated data for the input size 1000 and comparison of the algorithms  is given below.
 

 









