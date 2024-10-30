void main()
{
    int sum[4];
    int size;
    int res;
    size = 4;
    sum[0] = 7;
    sum[1] = 13;
    sum[2] = 9;
    sum[3] = 8;
    arrsum(size, sum, &res);
    print res;
}

//*** EXERCISE 7.2 ***
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

//*** EXERCISE 7.3 ***
/*void ForLoopArrsum(int n, int arr[], int *sump)
{
    int i;
    i = 0;
    int acc;
    for (i = 0; i < n; i = i + 1)
    {
        acc = acc + arr[i];
    }
    *sump = acc;
}*/