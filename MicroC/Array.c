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