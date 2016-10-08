Project 1

Group members:
Taylor Thibodeaux
Charles Thistlethwaite

In our program, our scanner read in tokens and used the parser class to translate them into node binary trees. There are two main methods in the 
parser class: parseExp() and parseRest(). parseExp() is Responsible for creating non-cons nodes while parseRest() divided up tokens and made cons
nodes depending on the content, and in doing so, built the binary tree. 

In the SPP class, the root of the tree is printed. The print method then traverses the binary tree recursively, printing each node and its children
nodes. Indentations were done using the int variable 'n' which was incremented once for every whitespace. 'n' was then passed to each child node
requiring indentation.

Error messages were reported for incorrect usage of RPARENs and DOTs.

Upon testing all given testcases and custom testcases, the proper output was returned. This held true upon submitting and verifying the program on the classes server. 
No further problems were found with pretty printing.