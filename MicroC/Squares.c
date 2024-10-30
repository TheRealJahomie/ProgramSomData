void main()
{
    int n;
    n = 20;
    int res;
    int arr[20];
    squares(n, arr);
    arrsum(n, arr, &res);
    print res;
}

//*** EXERCISE 7.2 ***
void squares(int n, int arr[])
{
    int i;
    i = 0;
    while (i < n)
    {
        arr[i] = i * i;
        i = i + 1;
    }
}

//*** EXERCISE 7.3 ***
/*
void ForLoopSquares(int n, int arr[])
{
    int i;
    i = 0;
    for (i = 0; i < n; i = i + 1)
    {
        arr[i] = i * i;
    }
}
*/

// Helper function from before
void arrsum(int n, int arr[], int *sump)
{
    int i;
    i = 0;
    int acc;
    while (i < n)
    {
        acc = acc + arr[i];
        i = i + 1;
    }
    *sump = acc;
}