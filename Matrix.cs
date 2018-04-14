using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_Matrix
{
    class Matrix
    {

        private int length;

        private int width;

        private int[,] matrix;

        public Matrix(int a, int b)
        {
            length = a;
            width = b;

             matrix = new int[a, b];

            Random r = new Random();

            for (int i = 0; i < a; i++)
            {               
                for (int j = 0; j < b; j++)
                {
                    

                    matrix[i, j] = r.Next() / 100000;

                }    

            } 

        }
          

        

        public void Display()
        {
            for(int i = 0; i <length; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j] + " ");   // Printing every element in a current row;
                }

                Console.WriteLine();                     // When the last element of the row is printed, it passes to the next one by steping down;
            }

            Console.Read();
        }

        public Matrix Inverse()
        {
            Matrix InvMartrix = new Matrix(length, width);

            Matrix unit = new Matrix(length, width);               // Building unit Matrix for nesting it in temMatrix;
            for(int i = 0; i<unit.length; i++)
            {
                for(int j = 0; j<width; j++)
                {
                    if(i == j)
                    {
                        unit.matrix[i, j] = 1;
                    }
                    else
                    {
                        unit.matrix[i, j] = 0;
                    }
                }
            }

            if (length != width)                   // Checking if the Matrix is Square;
            {   
                Console.WriteLine("Matrix can't have Inverse, because it is not square");       

                return this;
            }

            else
            {
                Matrix tempMatrix = new Matrix(length, 2 * length);           // Creating temporary matrix;

                for(int i = 0; i < tempMatrix.length; i++)                      
                {
                    for(int j = 0; j < tempMatrix.width; j++)                 // Nesting the Main and unit matrixes in it;
                    {
                        if( i < tempMatrix.width/2)
                        {
                            tempMatrix.matrix[i, j] = matrix[i, j];
                        }
                        else
                        {
                            tempMatrix.matrix[i, j] = matrix[i, j - length];
                        }
                    }

                    
                    // I don't know how to write the continuation of the Algorithm;
                }
                return this;
            }
           
        }

        public Matrix Transpose()
        {
            Matrix Tmatrix = new Matrix(width, length);

            for(int i = 0; i<Tmatrix.length; i++)
            {
                for(int j = 0; j<Tmatrix.width; j++)       
                {
                    Tmatrix.matrix[i, j] = matrix[j, i];    // Formula of Tranposed Matrix;
                }
            }

            return Tmatrix;                    

        }

        public Matrix Add(Matrix m)
        {
            if (length == m.length && width == m.width)               // Checking if the sizes of 2 martixes are equal;
            {
                Matrix NewMatrix = new Matrix(length, width);       // Creating new matrix that should be the product of addition and  returned by method;

                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        NewMatrix.matrix[i, j] = matrix[i, j] + m.matrix[i, j];         // Adding every 2 numbers with the same indexes;
                    }
                }

                return NewMatrix;
            }

            else
            {
                Console.WriteLine("Size of the Argument Matrix is Unmatchable");

                return this;
            }
        }

        public Matrix Mult(Matrix m)
        {
            if(m.length == width)
            {
                Matrix newMatrix = new Matrix(length, m.width);                

                for(int i = 0; i<length; i++)                                           // for each element of the new Matrix 
                {
                    for(int j = 0; j<m.width; j++)
                    {
                        for (int k = 0; k < width; k++)                 
                        {
                            newMatrix.matrix[i, j] += matrix[i, k] * matrix[k, j];    // Formula of multiplication;  
                        }
                    }

                }

                return newMatrix;
            }

            else
            {
                Console.WriteLine("Can not be Multiplied with that matrix");

                return this;
            }

            
        }

        public Matrix Mult(int a)
        {
            Matrix NewMatrix = new Matrix(length, width);                     // Creating new Matrix;

            for (int i = 0; i<length; i++)                          
            {
                for(int j = 0; j < width; j++)                                
                {
                    NewMatrix.matrix[i, j] *= a;                              // Multiplying every single number in the matrix;
                }

            }

            return NewMatrix;                             // returning new-created matrix;
        }

        public Matrix ScalMult(Matrix m)
        {
            if (m.length == length && m.width == width)
            {
                Matrix newMatrix = new Matrix(length, width);

                for (int i = 0; i < length; i++)
                {
                    for(int j = 0; j < width; j++)
                    {
                        newMatrix.matrix[i, j] = matrix[i, j] * m.matrix[i, j];
                    }
                }

                return newMatrix;
            }

            else
            {
                Console.WriteLine("Sizes of the argument Matrixes are not equal!");

                return this;
            }
        }

        public bool isOrthogonal(Matrix matrix)
        {
            return false;
        }

        public int theLargest()
        {
            int largest = matrix[0, 0];                             // Giving the 1st value of element of the matrix;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)                    // Checking, if the current element is bigger than the cuurent value of Largest;
                {
                    if (matrix[i, j] > largest)
                    {
                        largest = matrix[i, j];                    // If it is, largest gets the value of that element;
                    }
                }
            }

            return largest;                                     // returns the value;
        }

        public int theSmallest()
        {
            int smallest = matrix[0, 0];                      // Giving the 1st value of element of the matrix;

            for (int i = 0; i<length; i++)
            {
                for(int j = 0; j<width; j++)                  // Checking, if the current element is smaller than the cuurent value of Smallest;   
                {                                            
                    if(matrix[i,j]< smallest)
                    {
                        smallest = matrix[i, j];              // If it is, smallest gets the value of that element;
                    }
                }
            }

            return smallest;
        }




    }
}
