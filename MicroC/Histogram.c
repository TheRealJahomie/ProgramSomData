void main()
{
    int n;
    n = 7;
    int arr[7];
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;
    int max;
    max = 4; // ANSWER: If max = 3, then we get an array out of bounds error (sets freq[3] to 12), because we call freq[3], which is the 4th, hence it is greater than the max value of 3.
    int freq[4];
    histogram(n, arr, max, freq);
    print freq[0];
    print freq[1];
    print freq[2];
    print freq[3];
}

//*** EXERCISE 7.2 ***
void histogram(int n, int ns[], int max, int freq[])
{
    int c;
    int i;
    i = 0;
    while (i < max)
    {
        freq[i] = 0;
        i = i + 1;
    }
    i = 0;
    while (i < n)
    {
        c = ns[i];
        freq[c] = freq[c] + 1;
        i = i + 1;
    }
}

//*** EXERCISE 7.3 ***
void histogram(int n, int ns[], int max, int freq[])
{
    int c;
    int i;
    i = 0;
    for (i = 0; i < max; i = i + 1)
    {
        freq[i] = 0;
    }
    i = 0;
    for (i = 0; i < n; i = i + 1)
    {
        c = ns[i];
        freq[c] = freq[c] + 1;
    }
}