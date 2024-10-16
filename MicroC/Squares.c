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